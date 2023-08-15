// Copyright 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "LICENSE.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.Buffers;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.ComponentModel;
using System.Composition;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.IO.Hashing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using GZSkinsX.Contracts.Appx;
using GZSkinsX.Contracts.Mounter;

using Windows.Data.Json;
using Windows.Foundation;
using Windows.Storage;
using Windows.Web.Http;

namespace GZSkinsX.Services.Mounter;

[Shared, Export(typeof(IMounterService))]
internal sealed class MounterService : IMounterService
{
    private static Uri[] OnlineManifests { get; } = new Uri[]
    {
        new Uri("http://pan.x1.skn.lol/d/%20PanGZSkinsX/PackageManifest.json")
    };

    private readonly MounterSettings _mounterSettings;

    public event TypedEventHandler<IMounterService, bool>? IsRunningChanged;

    [ImportingConstructor]
    public MounterService(MounterSettings mounterSettings)
    {
        _mounterSettings = mounterSettings;

        var worker = new BackgroundWorker();
        worker.DoWork += DoSomething;
        worker.RunWorkerAsync();
    }

    // ヾ(•ω•`)o
    private async void DoSomething(object sender, DoWorkEventArgs e)
    {
        async Task CheckExitAsync()
        {
            while (true)
            {
                await Task.Delay(1240);

                try
                {
                    if (await App.DesktopExtensionMethods.IsMTRunning() is false)
                    {
                        IsRunningChanged?.Invoke(this, false);
                        break;
                    }
                }
                catch
                {
                }
            }

            await Task.CompletedTask;
        }

        async Task CheckRunAsync()
        {
            while (true)
            {
                await Task.Delay(1240);

                try
                {
                    if (await GetIsRunningAsync())
                    {
                        IsRunningChanged?.Invoke(this, true);
                        break;
                    }
                }
                catch
                {
                }
            }

            await Task.CompletedTask;
        }

        while (true)
        {
            try
            {
                if (await GetIsRunningAsync())
                {
                    IsRunningChanged?.Invoke(this, true);
                    await CheckExitAsync();
                }
                else
                {
                    IsRunningChanged?.Invoke(this, false);
                    await CheckRunAsync();
                }
            }
            catch
            {
            }
        }
    }

    public async Task<bool> CheckUpdatesAsync()
    {
        var metadata = await GetLocalMTPackageMetadataAsync();
        if (metadata.IsEmpty is false)
        {
            using var httpClient = new HttpClient();

            var onlineManifest = await DownloadPackageManifestAsync(httpClient);
            if (StringComparer.Ordinal.Equals(metadata.Version, onlineManifest.Version))
            {
                return false;
            }
        }

        return true;
    }

    private async Task<MTPackageManifest> DownloadPackageManifestAsync(HttpClient httpClient)
    {
        foreach (var uri in OnlineManifests)
        {
            var result = await httpClient.TryGetStringAsync(uri);
            if (result.Succeeded && JsonObject.TryParse(result.Value, out var jsonObject))
            {
                return new MTPackageManifest(
                    jsonObject[nameof(MTPackageManifest.Path)].GetString(),
                    jsonObject[nameof(MTPackageManifest.Version)].GetString());
            }
        }

        return MTPackageManifest.Empty;
    }

    private async Task<StorageFolder?> DownloadMTPackageAsync(HttpClient httpClient, Uri requestUri)
    {
        using var responseStream = await httpClient.TryGetInputStreamAsync(requestUri);

        if (responseStream.Succeeded)
        {
            using var zipArchive = new ZipArchive(responseStream.Value.AsStreamForRead());

            var metadataEntry = zipArchive.GetEntry("_metadata/package.json");
            if (metadataEntry is not null)
            {
                var rootFolder = await GetMounterRootFolderAsync();
                var destFolder = await CreateAnEmptyFolderAsync(rootFolder, Guid.NewGuid().ToString());

                zipArchive.ExtractToDirectory(destFolder.Path);
                return destFolder;
            }
            else
            {
                throw new FileNotFoundException("该包不存在有效的元数据信息！");
            }
        }

        return null;
    }

    public async Task<bool> GetIsRunningAsync()
    {
        return await App.DesktopExtensionMethods.IsMTRunning();
    }

    public async Task<MTPackageMetadata> GetLocalMTPackageMetadataAsync(params string[] filter)
    {
        var workingDirectory = await GetMounterWorkingDirectoryAsync();
        if (workingDirectory is not null)
        {
            return await GetLocalMTPackageMetadataAsync(workingDirectory, filter);
        }

        return MTPackageMetadata.Empty;
    }

    private async Task<MTPackageMetadata> GetLocalMTPackageMetadataAsync(StorageFolder workingDirectory, params string[] filter)
    {
        var metadataFolder = await workingDirectory.TryGetItemAsync("_metadata");
        if (metadataFolder is not null && metadataFolder.IsOfType(StorageItemTypes.Folder))
        {
            var metadataFile = await ((StorageFolder)metadataFolder).TryGetItemAsync("package.json");
            if (metadataFile is not null && metadataFile.IsOfType(StorageItemTypes.File))
            {
                return ParseMetadataFromString(await FileIO.ReadTextAsync(
                    (IStorageFile)metadataFile, Windows.Storage.Streams.UnicodeEncoding.Utf8), filter);
            }
        }

        return MTPackageMetadata.Empty;
    }

    private static MTPackageMetadata ParseMetadataFromString(string input, params string[] filter)
    {
        static IEnumerable<MTPackageMetadataStartUpArgument> GetStartUpArgs(IJsonValue jsonArray)
        {
            if (jsonArray.ValueType is JsonValueType.Array)
            {
                foreach (var item in jsonArray.GetArray())
                {
                    var startUpArgData = item.GetObject();
                    if (startUpArgData.TryGetValue("Name", out var name) &&
                        startUpArgData.TryGetValue("Value", out var value))
                    {
                        yield return new(name.GetString(), value.GetString());
                    }
                }

                yield break;
            }
        }

        if (JsonObject.TryParse(input, out var jsonObject) is false)
        {
            return MTPackageMetadata.Empty;
        }

        IJsonValue? tempValue;

        string author = string.Empty, version = string.Empty;
        string settingsFile = string.Empty, executableFile = string.Empty;
        string procStartupArgs = string.Empty, procTerminateArgs = string.Empty;
        var startUpArgs = Array.Empty<MTPackageMetadataStartUpArgument>();

        if (filter.Length is 0 || filter.Contains(nameof(MTPackageMetadata.Author), StringComparer.OrdinalIgnoreCase))
        {
            if (jsonObject.TryGetValue(nameof(MTPackageMetadata.Author), out tempValue))
            {
                author = tempValue.GetString();
            }
        }

        if (filter.Length is 0 || filter.Contains(nameof(MTPackageMetadata.Version), StringComparer.OrdinalIgnoreCase))
        {
            if (jsonObject.TryGetValue(nameof(MTPackageMetadata.Version), out tempValue))
            {
                version = tempValue.GetString();
            }
        }

        if (filter.Length is 0 || filter.Contains(nameof(MTPackageMetadata.SettingsFile), StringComparer.OrdinalIgnoreCase))
        {
            if (jsonObject.TryGetValue(nameof(MTPackageMetadata.SettingsFile), out tempValue))
            {
                settingsFile = tempValue.GetString();
            }
        }

        if (filter.Length is 0 || filter.Contains(nameof(MTPackageMetadata.ExecutableFile), StringComparer.OrdinalIgnoreCase))
        {
            if (jsonObject.TryGetValue(nameof(MTPackageMetadata.ExecutableFile), out tempValue))
            {
                executableFile = tempValue.GetString();
            }
        }

        if (filter.Length is 0 || filter.Contains(nameof(MTPackageMetadata.ProcStartupArgs), StringComparer.OrdinalIgnoreCase))
        {
            if (jsonObject.TryGetValue(nameof(MTPackageMetadata.ProcStartupArgs), out tempValue))
            {
                procStartupArgs = tempValue.GetString();
            }
        }

        if (filter.Length is 0 || filter.Contains(nameof(MTPackageMetadata.ProcTerminateArgs), StringComparer.OrdinalIgnoreCase))
        {
            if (jsonObject.TryGetValue(nameof(MTPackageMetadata.ProcTerminateArgs), out tempValue))
            {
                procTerminateArgs = tempValue.GetString();
            }
        }

        if (filter.Length is 0 || filter.Contains(nameof(MTPackageMetadata.OtherStartupArgs), StringComparer.OrdinalIgnoreCase))
        {
            if (jsonObject.TryGetValue(nameof(MTPackageMetadata.OtherStartupArgs), out tempValue))
            {
                startUpArgs = GetStartUpArgs(tempValue).ToArray();
            }
        }

        return new MTPackageMetadata(author, version, settingsFile, executableFile, procStartupArgs, procTerminateArgs, startUpArgs);
    }

    private async Task<StorageFolder> GetMounterRootFolderAsync()
    {
        return await GetOrCreateFolderAsync(ApplicationData.Current.RoamingFolder, "Mounter");
    }

    private async Task<StorageFolder?> GetMounterWorkingDirectoryAsync()
    {
        var workingDirectory = _mounterSettings.WorkingDirectory;
        if (workingDirectory is not null && workingDirectory != string.Empty)
        {
            var rootFolder = await GetMounterRootFolderAsync();
            var targetFolder = await rootFolder.TryGetItemAsync(workingDirectory);
            if (targetFolder is not null && targetFolder.IsOfType(StorageItemTypes.Folder))
            {
                return (StorageFolder)targetFolder;
            }
        }

        return null;
    }

    private async Task<StorageFolder> GetOrCreateFolderAsync(StorageFolder relativeTo, string folderName)
    {
        var targetFolder = await relativeTo.TryGetItemAsync(folderName);
        if (targetFolder is not null && targetFolder.IsOfType(StorageItemTypes.Folder))
        {
            return (StorageFolder)targetFolder;
        }
        else
        {
            return await relativeTo.CreateFolderAsync(folderName);
        }
    }

    private async Task<StorageFolder> CreateAnEmptyFolderAsync(StorageFolder relativeTo, string folderName)
    {
        var targetFolder = await relativeTo.TryGetItemAsync(folderName);
        if (targetFolder is not null && targetFolder.IsOfType(StorageItemTypes.Folder))
        {
            await targetFolder.DeleteAsync();
        }

        return await relativeTo.CreateFolderAsync(folderName);
    }

    public async Task<bool> VerifyLocalMTPackageIntegrityAsync()
    {
        var workingDirectory = await GetMounterWorkingDirectoryAsync();
        if (workingDirectory is null)
        {
            return false;
        }

        var metadataFolder = await workingDirectory.TryGetItemAsync("_metadata");
        if (metadataFolder is null || metadataFolder.IsOfType(StorageItemTypes.Folder) is false)
        {
            return false;
        }

        var metadataFile = await ((StorageFolder)metadataFolder).TryGetItemAsync("blockmap.json");
        if (metadataFile is null || metadataFile.IsOfType(StorageItemTypes.File) is false)
        {
            return false;
        }

        var blockMapContent = await FileIO.ReadTextAsync((IStorageFile)metadataFile);
        if (JsonObject.TryParse(blockMapContent, out var blockMapJson) is false ||
            blockMapJson.TryGetValue("Blocks", out var blocksArray) is false ||
            blocksArray.ValueType is not JsonValueType.Array)
        {
            return false;
        }

        var localBlockMap = blocksArray.GetArray().ToFrozenDictionary(
            a => ulong.Parse(a.GetObject()["Hash"].GetString(), CultureInfo.InvariantCulture),
            b => ulong.Parse(b.GetObject()["Checksum"].GetString(), CultureInfo.InvariantCulture));

        var parentFolderPathLength = workingDirectory.Path.Length + 1;
        var hashToPath = Directory.EnumerateFiles(workingDirectory.Path, "*", SearchOption.AllDirectories).ToFrozenDictionary(
            a => XxHash64.HashToUInt64(Encoding.UTF8.GetBytes(a[parentFolderPathLength..].Replace('\\', '/'))), b => b);

        foreach (var item in localBlockMap)
        {
            if (hashToPath.TryGetValue(item.Key, out var path) is false)
            {
                return false;
            }

            if (XxHash3.HashToUInt64(File.ReadAllBytes(path)) != item.Value)
            {
                return false;
            }
        }

        return true;
    }

    public async Task UpdateAsync(IProgress<double>? progress = null)
    {
        progress?.Report(0.0d);
        using var httpClient = new HttpClient();

        progress?.Report(12.0d);
        var workingDirectory = await GetMounterWorkingDirectoryAsync();

        progress?.Report(26.0d);

        var previousMetadata = workingDirectory is null ? MTPackageMetadata.Empty
            : await GetLocalMTPackageMetadataAsync(workingDirectory);

        progress?.Report(48.0d);
        var onlineManifest = await DownloadPackageManifestAsync(httpClient);

        if (StringComparer.Ordinal.Equals(previousMetadata.Version, onlineManifest.Version) is false)
        {
            progress?.Report(56.0d);

            var destFolder = await DownloadMTPackageAsync(httpClient, new(onlineManifest.Path));
            if (destFolder is null)
            {
                throw new InvalidOperationException("在尝试下载包时失败。");
            }

            progress?.Report(89.0d);

            // New Metadata
            var newMetadata = await GetLocalMTPackageMetadataAsync(destFolder);

            // Copy settings file
            if (workingDirectory is not null && previousMetadata.IsEmpty is false)
            {
                progress?.Report(95.0d);

                var settingsFilePath = Path.Combine(workingDirectory.Path, previousMetadata.SettingsFile);
                if (File.Exists(settingsFilePath))
                {
                    File.Copy(settingsFilePath, Path.Combine(destFolder.Path, newMetadata.SettingsFile));
                }

                progress?.Report(99.0d);
            }

            _mounterSettings.WorkingDirectory = destFolder.Name;
        }

        await TryClearDownloadCacheAsync();

        progress?.Report(100.0d);
    }

    public async Task TryClearDownloadCacheAsync()
    {
        var targetFolderName = _mounterSettings.WorkingDirectory;

        try
        {
            var rootFolder = await GetMounterRootFolderAsync();
            foreach (var item in await rootFolder.GetItemsAsync())
            {
                if (StringComparer.Ordinal.Equals(item.Name, targetFolderName) && item.IsOfType(StorageItemTypes.Folder))
                {
                    continue;
                }

                await item.DeleteAsync();
            }
        }
        catch (Exception excp)
        {
            AppxContext.LoggingService.LogWarning(
               $"""
                    MounterService      : Failed to clear the download cache.
                    ExceptionMessage    : "{excp.Message}".
                    StackTrace          : "{excp.StackTrace}".
                """);
        }
    }

    public async Task LaunchAsync()
    {
        var localPackageMetadata =
            await GetLocalMTPackageMetadataAsync(
            nameof(MTPackageMetadata.ExecutableFile),
            nameof(MTPackageMetadata.ProcStartupArgs));

        if (localPackageMetadata.IsEmpty is false)
        {
            var workingDirectory = await GetMounterWorkingDirectoryAsync();
            if (workingDirectory is not null)
            {
                var executableFile = Path.Combine(workingDirectory.Path, localPackageMetadata.ExecutableFile);
                await App.DesktopExtensionMethods.ProcessLaunch(executableFile, localPackageMetadata.ProcStartupArgs, true);
            }
        }
    }

    public async Task LaunchAsync(string args)
    {
        var localPackageMetadata =
            await GetLocalMTPackageMetadataAsync(
            nameof(MTPackageMetadata.ExecutableFile));

        if (localPackageMetadata.IsEmpty is false)
        {
            var workingDirectory = await GetMounterWorkingDirectoryAsync();
            if (workingDirectory is not null)
            {
                var executableFile = Path.Combine(workingDirectory.Path, localPackageMetadata.ExecutableFile);
                await App.DesktopExtensionMethods.ProcessLaunch(executableFile, args, true);
            }
        }
    }

    public async Task TerminateAsync()
    {
        var localPackageMetadata =
            await GetLocalMTPackageMetadataAsync(
            nameof(MTPackageMetadata.ExecutableFile),
            nameof(MTPackageMetadata.ProcTerminateArgs));

        if (localPackageMetadata.IsEmpty is false)
        {
            var workingDirectory = await GetMounterWorkingDirectoryAsync();
            if (workingDirectory is not null)
            {
                var executableFile = Path.Combine(workingDirectory.Path, localPackageMetadata.ExecutableFile);
                await App.DesktopExtensionMethods.ProcessLaunch(executableFile, localPackageMetadata.ProcTerminateArgs, true);
            }
        }
    }

    private readonly struct MTPackageManifest
    {
        public static readonly MTPackageManifest Empty = new();

        public readonly string Path;

        public readonly string Version;

        public readonly bool IsEmpty;

        public MTPackageManifest()
        {
            Path = string.Empty;
            Version = string.Empty;
            IsEmpty = true;
        }

        public MTPackageManifest(string path, string version)
        {
            Path = path;
            Version = version;
            IsEmpty = false;
        }
    }
}

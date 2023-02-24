// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using GZSkinsX.Composition.Cache;

using Microsoft.VisualStudio.Composition;

namespace GZSkinsX.Composition;

/// <summary>
/// ����ö�� MEF (v2) ��������������� VS-MEF
/// </summary>
public sealed class CompositionContainerV2
{
    /// <summary>
    /// ��ö�ٵ����Ŀ¼
    /// </summary>
    private readonly AssemblyCatalogV2 _assemablyCatalog;

    /// <summary>
    /// ��ʼ�� <see cref="CompositionContainerV2"/> ����ʵ��
    /// </summary>
    /// <param name="catalog">���Ŀ¼</param>
    public CompositionContainerV2(AssemblyCatalogV2 catalog)
    {
        _assemablyCatalog = catalog;
    }

    /// <summary>
    /// �����еĻ����м��ػ��Ǵ���һ���µ� <see cref="ExportProvider"/> ʵ��
    /// </summary>
    /// <param name="useCache">�Ƿ�ʹ�û���</param>
    /// <returns>�������д�����  <see cref="ExportProvider"/> ʵ��</returns>
    public async Task<ExportProvider> CreateExportProviderAsync(string? cacheFilename)
    {
        return (await CreateExportProviderFactoryCoreAsync(cacheFilename)).CreateExportProvider();
    }

    /// <summary>
    /// �����еĻ����м��ػ��Ǵ���һ���µ� <see cref="IExportProviderFactory"/> ʵ��
    /// </summary>
    /// <param name="useCache">�Ƿ�ʹ�û���</param>
    /// <returns>�������д����� <see cref="IExportProviderFactory"/> ʵ��</returns>
    private async Task<IExportProviderFactory> CreateExportProviderFactoryCoreAsync(string? cacheFilename)
    {
        var resolver = Resolver.DefaultInstance;
        if (string.IsNullOrEmpty(cacheFilename) && File.Exists(cacheFilename))
        {
            var factory = await TryGetCachedExportProviderFactoryAsync(resolver, cacheFilename);
            if (factory != null)
            {
                return factory;
            }
        }

        return await CreateExportProviderFactoryAsync(resolver, cacheFilename);
    }

    /// <summary>
    /// ö�ٳ��򼯲����� <see cref="IExportProviderFactory"/>
    /// </summary>
    /// <param name="resolver">Ĭ�Ͻ�����</param>
    /// <returns>�������д�����  <see cref="IExportProviderFactory"/> ʵ��</returns>
    private async Task<IExportProviderFactory> CreateExportProviderFactoryAsync(Resolver resolver, string? cacheFilename)
    {
        var discovery = new AttributedPartDiscovery(resolver, true);
        var parts = await discovery.CreatePartsAsync(_assemablyCatalog.Parts);
        Debug.Assert(parts.ThrowOnErrors() == parts);

        var composableCatalog = ComposableCatalog.Create(resolver).AddParts(parts);
        var configuragtion = CompositionConfiguration.Create(composableCatalog);
        Debug.Assert(configuragtion.ThrowOnErrors() == configuragtion);

        await SaveMefCacheAsync(configuragtion, cacheFilename);

        return configuragtion.CreateExportProviderFactory();
    }

    /// <summary>
    /// �������ѻ�����ļ��л�ȡ <see cref="IExportProviderFactory"/> ����
    /// </summary>
    /// <param name="resolver">Ĭ�Ͻ�����</param>
    /// <returns>�ӻ����л�ȡ���� <see cref="IExportProviderFactory"/> ���������ȡʧ���򷵻� null </returns>
    private async Task<IExportProviderFactory?> TryGetCachedExportProviderFactoryAsync(Resolver resolver, string? cacheFileName)
    {
        try
        {
            using var cachedStream = File.OpenRead(cacheFileName);
            using var reader = new CacheStreamReader(cachedStream);
            var oldCache = await reader.ReadAssemablyCatalogCacheAsync();
            var newCache = _assemablyCatalog.Cache;
            if (newCache.Equals(oldCache))
            {
                return await reader.ReadCompositionCacheAsync(resolver);
            }
        }
        catch
        {
            return null;
        }

        return null;
    }

    /// <summary>
    /// ����ǰ <see cref="CompositionConfiguration"/> ����Ļ������ļ���ʽ���浽����
    /// </summary>
    /// <param name="configuration">���ڻ���Ķ���</param>
    private async Task SaveMefCacheAsync(CompositionConfiguration configuration, string? cacheFilename)
    {
        if (string.IsNullOrEmpty(cacheFilename)) return;

        var isCreated = false;
        var canDelete = true;

        try
        {
            using var cachedStream = File.Create(cacheFilename);
            isCreated = true;

            using var writer = new CacheStreamWriter();
            await writer.WriteAssemablyCatalogCacheAsync(_assemablyCatalog.Cache);
            await writer.WriteCompositionCacheAsync(configuration);
            await writer.SaveAsync(cachedStream);

            canDelete = false;
        }
        catch when (isCreated && canDelete)
        {
            try
            {
                File.Delete(cacheFilename);
            }
            catch
            {
            }
        }
    }
}

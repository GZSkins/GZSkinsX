// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.Composition;
using System.Threading.Tasks;

using GZSkinsX.Api.AccessCache;
using GZSkinsX.Api.Settings;
using GZSkinsX.DotNet.Diagnostics;

using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.AccessCache;

namespace GZSkinsX.AccessCache;

/// <inheritdoc cref="IMostRecentlyUsedService"/>
[Shared, Export(typeof(IMostRecentlyUsedService))]
internal sealed class MostRecentlyUsedService : IMostRecentlyUsedService
{
    /// <summary>
    /// ��ʾ��ǰ���ýڵ�� <seealso cref="Guid"/> �ַ���ֵ
    /// </summary>
    private const string THE_GUID = "6A50EFFD-185B-42FC-8509-14BE6EEC74EE";

    /// <summary>
    /// ���ڴ洢�������ݵ����ݽڵ�
    /// </summary>
    private readonly ISettingsSection _settingsSection;

    /// <summary>
    /// �ڲ������ʹ�� (MRU) �б���
    /// </summary>
    private readonly StorageItemMostRecentlyUsedList _mostRecentlyUsedList;

    /// <inheritdoc/>
    public AccessListEntryView Entries => _mostRecentlyUsedList.Entries;

    /// <inheritdoc/>
    public uint MaximumItemsAllowed => _mostRecentlyUsedList.MaximumItemsAllowed;

    /// <inheritdoc/>
    public event TypedEventHandler<IMostRecentlyUsedService, ItemRemovedEventArgs>? ItemRemoved;

    /// <summary>
    /// ��ʼ�� <see cref="MostRecentlyUsedService"/> ����ʵ��
    /// </summary>
    [ImportingConstructor]
    public MostRecentlyUsedService(ISettingsService settingsService)
    {
        _settingsSection = settingsService.GetOrCreateSection(THE_GUID);
        _mostRecentlyUsedList = StorageApplicationPermissions.MostRecentlyUsedList;
        _mostRecentlyUsedList.ItemRemoved += OnItemRemoved;
    }

    /// <summary>
    /// �Խӿ��ж�����¼� <seealso cref="IMostRecentlyUsedService.ItemRemoved"/> ���д���֪ͨ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void OnItemRemoved(StorageItemMostRecentlyUsedList sender, ItemRemovedEventArgs args)
    {
        // ���ݵ�ǰ������󣬶����� MRU �б��Ա��� MRU �б����ⲿ��ʹ��
        ItemRemoved?.Invoke(this, args);
    }

    /// <inheritdoc/>
    public void Add(IStorageItem storageItem, string name)
    {
        if (storageItem is null)
        {
            throw new ArgumentNullException(nameof(storageItem));
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var token = _settingsSection.Attribute<string>(name);
        if (string.IsNullOrEmpty(token))
        {
            token = _mostRecentlyUsedList.Add(storageItem, name);
            _settingsSection.Attribute(name, token);
        }
        else
        {
            _mostRecentlyUsedList.AddOrReplace(token, storageItem, name);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="storageItem"></param>
    /// <param name="name"></param>
    /// <param name="visibility"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Add(IStorageItem storageItem, string name, RecentStorageItemVisibility visibility)
    {
        if (storageItem is null)
        {
            throw new ArgumentNullException(nameof(storageItem));
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var token = _settingsSection.Attribute<string>(name);
        if (string.IsNullOrEmpty(token))
        {
            token = _mostRecentlyUsedList.Add(storageItem, name, visibility);
            _settingsSection.Attribute(name, token);
        }
        else
        {
            _mostRecentlyUsedList.AddOrReplace(token, storageItem, name, visibility);
        }
    }

    /// <inheritdoc/>
    public bool CheckAccess(IStorageItem item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        return _mostRecentlyUsedList.CheckAccess(item);
    }

    /// <inheritdoc/>
    public void Clear()
    {
        _mostRecentlyUsedList.Clear();
    }

    /// <inheritdoc/>
    public bool ContainsItem(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var token = _settingsSection.Attribute<string>(name);
        if (token is null)
        {
            return false;
        }

        return _mostRecentlyUsedList.ContainsItem(token);
    }

    /// <inheritdoc/>
    public async Task<StorageFile> GetFileAsync(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var token = _settingsSection.Attribute<string>(name);
        Debug2.Assert(token != null);
        if (token is null)
        {
            throw new AccessCacheItemNotFoundException(name);
        }

        return await _mostRecentlyUsedList.GetFileAsync(token);
    }

    /// <inheritdoc/>
    public async Task<StorageFile> GetFileAsync(string name, AccessCacheOptions options)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var token = _settingsSection.Attribute<string>(name);
        Debug2.Assert(token != null);
        if (token is null)
        {
            throw new AccessCacheItemNotFoundException(name);
        }

        return await _mostRecentlyUsedList.GetFileAsync(token, options);
    }

    /// <inheritdoc/>
    public async Task<StorageFolder> GetFolderAsync(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var token = _settingsSection.Attribute<string>(name);
        Debug2.Assert(token != null);
        if (token is null)
        {
            throw new AccessCacheItemNotFoundException(name);
        }

        return await _mostRecentlyUsedList.GetFolderAsync(token);
    }

    /// <inheritdoc/>
    public async Task<StorageFolder> GetFolderAsync(string name, AccessCacheOptions options)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var token = _settingsSection.Attribute<string>(name);
        Debug2.Assert(token != null);
        if (token is null)
        {
            throw new AccessCacheItemNotFoundException(name);
        }

        return await _mostRecentlyUsedList.GetFolderAsync(token, options);
    }

    /// <inheritdoc/>
    public async Task<IStorageItem> GetItemAsync(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var token = _settingsSection.Attribute<string>(name);
        Debug2.Assert(token != null);
        if (token is null)
        {
            throw new AccessCacheItemNotFoundException(name);
        }

        return await _mostRecentlyUsedList.GetItemAsync(token);
    }

    /// <inheritdoc/>
    public async Task<IStorageItem> GetItemAsync(string name, AccessCacheOptions options)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var token = _settingsSection.Attribute<string>(name);
        Debug2.Assert(token != null);
        if (token is null)
        {
            throw new AccessCacheItemNotFoundException(name);
        }

        return await _mostRecentlyUsedList.GetItemAsync(token, options);
    }

    /// <inheritdoc/>
    public void Remove(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var token = _settingsSection.Attribute<string>(name);
        if (token is not null)
        {
            _mostRecentlyUsedList.Remove(token);
        }
    }
}

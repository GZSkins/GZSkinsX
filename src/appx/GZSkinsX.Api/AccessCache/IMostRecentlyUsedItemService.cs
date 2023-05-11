// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;

using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.AccessCache;

namespace GZSkinsX.Api.AccessCache;

/// <summary>
/// �ṩ�����ʹ�� (MRU) �Ĵ洢���б���й����ɸ����û�������ʵ� (�ļ����ļ���)
/// </summary>
public interface IMostRecentlyUsedItemService : IAccessCacheService
{
    /// <summary>
    /// �����ʹ�õ� (MRU) �б���ɾ���洢��ʱ����
    /// </summary>
    event TypedEventHandler<IMostRecentlyUsedItemService, ItemRemovedEventArgs>? ItemRemoved;

    /// <summary>
    /// ���µĴ洢��͹�����������ӵ����ʹ�õ� (MRU) �б��У�ָ����ɼ��Է�Χ
    /// </summary>
    /// <param name="storageItem">Ҫ��ӵĴ洢��</param>
    /// <param name="name">Ҫ��洢�����������</param>
    /// <param name="visibility">�б��д洢��ɼ��Եķ�Χ</param>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> �� <paramref name="storageItem"/> ��������Ĭ��ֵΪ null</exception>
    void Add(IStorageItem storageItem, string name, RecentStorageItemVisibility visibility);
}

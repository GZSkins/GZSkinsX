// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.Threading.Tasks;

using Windows.Storage;
using Windows.Storage.AccessCache;

namespace GZSkinsX.Api.AccessCache;

/// <summary>
/// ��ʾ�Է��ʵĴ洢����л������ķ��񡣸ýӿ�Ϊһ��ͨ�û����ӿڣ������� <seealso cref="IFutureAccessService"/>
/// �� <seealso cref="IMostRecentlyUsedItemService"/>��������������ʵ�ֺ͵������෴������ӿ�����Զ���ᱻʵ�ֲ�����
/// </summary>
public interface IAccessCacheService
{
    /// <summary>
    /// ��ȡ���ڴӷ����б��м����洢��Ķ���
    /// </summary>
    AccessListEntryView Entries { get; }

    /// <summary>
    /// ��ȡ�����б���԰��������洢����
    /// </summary>
    uint MaximumItemsAllowed { get; }

    /// <summary>
    /// ���µĴ洢����ӵ������б�
    /// </summary>
    /// <param name="storageItem">Ҫ��ӵĴ洢��</param>
    /// <param name="name">Ҫ��洢����������ơ�</param>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> �� <paramref name="storageItem"/> ��������Ĭ��ֵΪ null</exception>
    void Add(IStorageItem storageItem, string name);

    /// <summary>
    /// ȷ��Ӧ���Ƿ���Ȩ���ʷ����б��е�ָ���洢��
    /// </summary>
    /// <param name="item">Ҫ������Ȩ�޵Ĵ洢��</param>
    /// <returns>���Ӧ�ÿ��Է��ʴ洢����Ϊ True������Ϊ false</returns>
    /// <exception cref="ArgumentNullException"><paramref name="item"/> ��������Ĭ��ֵΪ null</exception>
    public bool CheckAccess(IStorageItem item);

    /// <summary>
    /// �ӷ����б���ɾ�����д洢��
    /// </summary>
    public void Clear();

    /// <summary>
    /// ȷ�������б��Ƿ����ָ���Ĵ洢��
    /// </summary>
    /// <param name="name">Ҫ���ҵĴ洢�������</param>
    /// <returns>��������б����ָ���Ĵ洢����Ϊ True������Ϊ false</returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> ��������Ĭ��ֵΪ null</exception>
    bool ContainsItem(string name);

    /// <summary>
    /// ���б��м���ָ���� <see cref="StorageFile"/>
    /// </summary>
    /// <param name="name">Ҫ������ <see cref="StorageFile"/> ������</param>
    /// <returns>�˷����ɹ���ɺ󣬽�������ָ�����ƹ����� <see cref="StorageFile"/></returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> ��������Ĭ��ֵΪ null</exception>
    /// <exception cref="AccessCacheItemNotFoundException">δ���б��м����������ƹ����� <see cref="StorageFile"/></exception>
    Task<StorageFile> GetFileAsync(string name);

    /// <summary>
    /// ʹ��ָ����ѡ����б��м���ָ���� <see cref="StorageFile"/> 
    /// </summary>
    /// <param name="name">Ҫ������ <see cref="StorageFile"/> ������</param>
    /// <param name="options">����Ӧ�÷�����ʱҪʹ�õ���Ϊ��ö��ֵ��</param>
    /// <returns>�˷����ɹ���ɺ󣬽�������ָ�����ƹ����� <see cref="StorageFile"/></returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> ��������Ĭ��ֵΪ null</exception>
    /// <exception cref="AccessCacheItemNotFoundException">δ���б��м����������ƹ����� <see cref="StorageFile"/></exception>
    Task<StorageFile> GetFileAsync(string name, AccessCacheOptions options);

    /// <summary>
    /// ���б��м���ָ���� <see cref="StorageFolder"/> 
    /// </summary>
    /// <param name="name">Ҫ������ <see cref="StorageFolder"/> ������</param>
    /// <returns>�˷����ɹ���ɺ�����������ָ�����ƹ����� <see cref="StorageFolder"/></returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> ��������Ĭ��ֵΪ null</exception>
    /// <exception cref="AccessCacheItemNotFoundException">δ���б��м����������ƹ����� <see cref="StorageFolder"/></exception>
    Task<StorageFolder> GetFolderAsync(string name);

    /// <summary>
    /// ʹ��ָ����ѡ����б��м���ָ���� <see cref="StorageFolder"/> 
    /// </summary>
    /// <param name="name">Ҫ������ <see cref="StorageFolder"/> ������</param>
    /// <param name="options">ö��ֵ����ֵ����Ӧ�÷�����ĿʱҪʹ�õ���Ϊ</param>
    /// <returns>�˷����ɹ���ɺ�����������ָ�����ƹ����� <see cref="StorageFolder"/></returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> ��������Ĭ��ֵΪ null</exception>
    /// <exception cref="AccessCacheItemNotFoundException">δ���б��м����������ƹ����� <see cref="StorageFolder"/></exception>
    Task<StorageFolder> GetFolderAsync(string name, AccessCacheOptions options);

    /// <summary>
    /// ���б��м���ָ������ (�����ļ����ļ���)
    /// </summary>
    /// <param name="name">Ҫ�������������</param>
    /// <returns>�˷����ɹ���ɺ�����������ָ����ǹ������� (���� <see cref="IStorageItem"/>)</returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> ��������Ĭ��ֵΪ null</exception>
    /// <exception cref="AccessCacheItemNotFoundException">δ���б��м����������ƹ����� <see cref="IStorageItem"/></exception>
    Task<IStorageItem> GetItemAsync(string name);

    /// <summary>
    /// ʹ��ָ����ѡ����б��м���ָ������ (�����ļ����ļ���)
    /// </summary>
    /// <param name="name">Ҫ�������������</param>
    /// <param name="options">����Ӧ�÷�����ʱҪʹ�õ���Ϊ��ö��ֵ��</param>
    /// <returns>�˷����ɹ���ɺ�����������ָ����ǹ������� (���� <see cref="IStorageItem"/>)</returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> ��������Ĭ��ֵΪ null</exception>
    /// <exception cref="AccessCacheItemNotFoundException">δ���б��м����������ƹ����� <see cref="IStorageItem"/></exception>
    Task<IStorageItem> GetItemAsync(string name, AccessCacheOptions options);

    /// <summary>
    /// �ӷ����б���ɾ��ָ���Ĵ洢��
    /// </summary>
    /// <param name="name">Ҫɾ���Ĵ洢�����������</param>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> ��������Ĭ��ֵΪ null</exception>
    void Remove(string name);
}

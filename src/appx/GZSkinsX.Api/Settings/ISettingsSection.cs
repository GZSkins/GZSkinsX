// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;

namespace GZSkinsX.Api.Settings;

/// <summary>
/// ��ʾλ�ڳ��������е��ӽڵ�����
/// </summary>
public interface ISettingsSection
{
    /// <summary>
    /// ��ǰ���ýڵ������
    /// </summary>
    string Name { get; }

    /// <summary>
    /// ��ǰ���ýڵ������
    /// </summary>
    SettingsType Type { get; }

    /// <summary>
    /// ��ȡ��ָ���ļ�������ֵ
    /// </summary>
    /// <param name="key">Ҫ��ȡ��ֵ�ļ�</param>
    /// <returns>��ָ���ļ��������ֵ</returns>
    /// <exception cref="InvalidOperationException">��ǰ�����ѱ��ͷŻ�ɾ��</exception>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> ��������Ĭ��ֵΪ null</exception>
    object? Attribute(string key);

    /// <summary>
    /// ��ȡ��ָ���ļ�������ֵ
    /// </summary>
    /// <typeparam name="TValue">ָ��ֵ������</typeparam>
    /// <param name="key">Ҫ��ȡ��ֵ�ļ�</param>
    /// <returns>��ָ���ļ�ƥ���Ԫ��</returns>
    /// <exception cref="InvalidOperationException">��ǰ�����ѱ��ͷŻ�ɾ��</exception>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> ��������Ĭ��ֵΪ null</exception>
    TValue? Attribute<TValue>(string key);

    /// <summary>
    /// ������ָ���ļ�������ֵ
    /// </summary>
    /// <param name="key">Ҫ���õ�ֵ�ļ�</param>
    /// <param name="value">Ҫ���õļ���ֵ</param>
    /// <exception cref="InvalidOperationException">��ǰ�����ѱ��ͷŻ�ɾ��</exception>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> �� <paramref name="value"/> ��������Ĭ��ֵΪ null</exception>
    void Attribute(string key, object value);

    /// <summary>
    /// �ӵ�ǰ�ڵ���ɾ����ָ���ļ�ƥ���Ԫ��
    /// </summary>
    /// <param name="key">Ҫɾ����Ԫ�صļ�</param>
    /// <returns>����ڸýڵ��гɹ��ҵ���Ԫ�ز�ɾ���򷵻� true�����򷵻� false</returns>
    /// <exception cref="InvalidOperationException">��ǰ�����ѱ��ͷŻ�ɾ��</exception>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> ��������Ĭ��ֵΪ null</exception>
    bool Delete(string key);

    /// <summary>
    /// �ӵ�ǰ�ڵ���ɾ����ָ��������ƥ����ӽڵ�����
    /// </summary>
    /// <param name="name">Ҫɾ�����ӽڵ����õ�����</param>
    void DeleteSection(string name);

    /// <summary>
    /// �ӵ�ǰ�ڵ��л�ȡ�򴴽���ָ��������ƥ����ӽڵ�����
    /// </summary>
    /// <param name="name">Ҫ��ȡ���ӽڵ����õ�����</param>
    /// <returns>����ҵ�ƥ���Ԫ����᷵�ظö��󣻷��򽫻ᴴ��һ���µ��ӽڵ�����</returns>
    /// <exception cref="InvalidOperationException">��ǰ�����ѱ��ͷŻ�ɾ��</exception>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> ��������Ĭ��ֵΪ null</exception>
    ISettingsSection GetOrCreateSection(string name);
}

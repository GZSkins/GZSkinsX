// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;

namespace GZSkinsX.SDK.Settings;

/// <summary>
/// �ṩ�洢Ӧ�ó������õķ��񣬿����ڴ洢�������ݻ���������
/// </summary>
public interface ISettingsService
{
    /// <summary>
    /// �ӵ�ǰӦ�ó���������ɾ����ָ��������ƥ����ӽڵ�����
    /// </summary>
    /// <param name="name">Ҫɾ�����ӽڵ���������</param>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> ��������Ĭ��ֵΪ null</exception>
    void DeleteSection(string name);

    /// <summary>
    /// �ӵ�ǰӦ�ó���������ɾ����ָ�������Ƽ�������ƥ����ӽڵ�����
    /// </summary>
    /// <param name="name">Ҫɾ�����ӽڵ���������</param>
    /// <param name="type">Ҫɾ�����ӽڵ���������</param>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> ��������Ĭ��ֵΪ null</exception>
    void DeleteSection(string name, SettingsType type);

    /// <summary>
    /// �ӵ�ǰӦ�ó��������л�ȡ�򴴽���ָ��������ƥ����ӽڵ�����
    /// </summary>
    /// <param name="name">Ҫ��ȡ���ӽڵ����õ�����</param>
    /// <returns>����ҵ�ƥ���Ԫ����᷵�ظö��󣻷��򽫻ᴴ��һ���µ��ӽڵ�����</returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> ��������Ĭ��ֵΪ null</exception>
    ISettingsSection GetOrCreateSection(string name);

    /// <summary>
    /// �ӵ�ǰӦ�ó��������л�ȡ�򴴽���ָ�������Ƽ�������ƥ����ӽڵ�����
    /// </summary>
    /// <param name="name">Ҫ��ȡ���ӽڵ����õ�����</param>
    /// <param name="type">Ҫ��ȡ���ӽڵ���������</param>
    /// <returns>����ҵ�ƥ���Ԫ����᷵�ظö��󣻷��򽫻ᴴ��һ���µ��ӽڵ�����</returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> ��������Ĭ��ֵΪ null</exception>
    ISettingsSection GetOrCreateSection(string name, SettingsType type);
}

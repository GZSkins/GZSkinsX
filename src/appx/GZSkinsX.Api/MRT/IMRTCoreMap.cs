// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.Threading.Tasks;

namespace GZSkinsX.SDK.MRT;

/// <summary>
/// �����Դ�ļ��ϣ�ͨ�����ڻ�ȡ���ػ���Դ����
/// </summary>
public interface IMRTCoreMap
{
    /// <summary>
    /// ��ȡĬ������������ָ������Դ��ʶ����ƥ��ı��ػ���Դ
    /// </summary>
    /// <param name="resourceKey">ָ��Ϊ���ƻ����õ���Դ��ʶ��</param>
    /// <returns>���ʶ�����ϵı��ػ���Դ���ֽ���������</returns>
    /// <exception cref="ArgumentNullException"><paramref name="resourceKey"/> ��������Ĭ��ֵΪ null</exception>
    Task<byte[]> GetBytesAsync(string resourceKey);

    /// <summary>
    /// ��ȡĬ������������ָ������Դ��ʶ����ƥ��ı��ػ���Դ
    /// </summary>
    /// <param name="resourceKey">ָ��Ϊ���ƻ����õ���Դ��ʶ��</param>
    /// <returns>���ʶ�����ϵı��ػ���Դ���ַ�������</returns>
    /// <exception cref="ArgumentNullException"><paramref name="resourceKey"/> ��������Ĭ��ֵΪ null</exception>
    string GetString(string resourceKey);

    /// <summary>
    /// �ӵ�ǰĬ���������л�ȡ�ض�����Դ�Ӽ�
    /// </summary>
    /// <param name="reference">���ڱ�ʶ������������Դӳ���ʶ��</param>
    /// <returns>���� <seealso cref="IMRTCoreMap"/></returns>
    /// <exception cref="ArgumentNullException"><paramref name="reference"/> ��������Ĭ��ֵΪ null</exception>
    IMRTCoreMap GetSubtree(string reference);
}

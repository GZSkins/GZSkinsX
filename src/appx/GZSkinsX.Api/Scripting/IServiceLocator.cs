// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace GZSkinsX.Api.Scripting;

/// <summary>
/// �ṩ��ȡ�ѵ��������͵���������Χ����Ӧ�ó�����ص��������
/// </summary>
public interface IServiceLocator
{
    /// <summary>
    /// ���Ѽ��ص���������л�ȡ����������ʵ��
    /// </summary>
    /// <typeparam name="T">��Ҫ��ȡ������</typeparam>
    /// <returns>���� <typeparamref name="T"/> ��ʵ��</returns>
    T Resolve<T>() where T : class;

    /// <summary>
    /// ���Դ��Ѽ��ص���������л�ȡ����������ʵ��
    /// </summary>
    /// <typeparam name="T">ExportAttribute ���������ĵ�������</typeparam>
    /// <param name="value">�ѻ�ȡ��������ʵ�����������ȡʧ����᷵�� default</param>
    /// <returns>����ȡ�ɹ�ʱ���� true�����򷵻� false</returns>
    bool TryResolve<T>([NotNullWhen(true)] out T? value) where T : class;
}

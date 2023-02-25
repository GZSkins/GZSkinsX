// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.Runtime.InteropServices;
using System.Text;

using Windows.ApplicationModel;

namespace GZSkinsX.Api.Appx;

/// <summary>
/// ��ǰ Appx Ӧ�õ�������
/// </summary>
public static class AppxContext
{
    /// <summary>
    /// ��ȡ��ǰӦ�ð�������
    /// </summary>
    /// <param name="packageFullNameLength">���ڷ����ַ�������</param>
    /// <param name="packageFullName">���ڴ洢Ӧ�ð�����</param>
    /// <returns></returns>
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern int GetCurrentPackageFullName(
        ref int packageFullNameLength,
        StringBuilder? packageFullName);

    /// <summary>
    /// ��ʼ�� <see cref="AppxContext"/> �ľ�̬��Ա
    /// </summary>
    static AppxContext()
    {
        var length = 0;

        IsMSIX = GetCurrentPackageFullName(ref length, null) != 15700L;
        AppxDirectory = IsMSIX ? Package.Current.InstalledLocation.Path : Environment.CurrentDirectory;
        AppxVersion = new Version(2, 0, 0, 0);
    }

    /// <summary>
    /// ��ȡ��ǰӦ�ó����Ƿ�Ϊ MSIX Ӧ��
    /// </summary>
    public static bool IsMSIX { get; }

    /// <summary>
    /// ��ȡ��ǰӦ�ó����Ŀ¼
    /// <para>
    /// ���� <see cref="IsMSIX"/> �Ĳ�ͬ�����ص�Ŀ¼Ҳ��ͬ
    /// </para>
    /// </summary>
    public static string AppxDirectory { get; }

    /// <summary>
    /// ��ȡ��ǰӦ�ó���汾
    /// </summary>
    public static Version AppxVersion { get; }
}

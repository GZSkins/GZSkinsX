// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;

using Windows.ApplicationModel;

namespace GZSkinsX.Api.Appx;

/// <summary>
/// ��ǰ Appx Ӧ�õ�������
/// </summary>
public static class AppxContext
{
    /// <summary>
    /// ��ʼ�� <see cref="AppxContext"/> �ľ�̬��Ա
    /// </summary>
    static AppxContext()
    {
        AppxDirectory = Package.Current.InstalledLocation.Path;
        AppxVersion = new Version(2, 0, 0, 0);
    }

    /// <summary>
    /// ��ȡ��ǰӦ�ó����Ŀ¼
    /// </summary>
    public static string AppxDirectory { get; }

    /// <summary>
    /// ��ȡ��ǰӦ�ó���汾
    /// </summary>
    public static Version AppxVersion { get; }
}

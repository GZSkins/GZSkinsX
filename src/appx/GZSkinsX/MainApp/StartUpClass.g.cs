﻿// <auto-generated by App.g.tt (t4 template file). />
 
// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace GZSkinsX.MainApp;

partial class StartUpClass
{
    /// <summary>
    /// 获取当前 Appx 引用程序集
    /// </summary>
    private static global::System.Collections.Generic.IEnumerable<global::System.Reflection.Assembly> GetAssemblies()
    {
        // Main Appx
        {
            // Self Assembly
            yield return typeof(global::GZSkinsX.MainApp.App).Assembly;
            // GZSkinsX.Api
            yield return typeof(global::GZSkinsX.SDK.Appx.IAppxWindow).Assembly;
        }

        // Extensions
        {
            // GZSkinsX.Extensions.CreatorStudio
            yield return typeof(global::GZSkinsX.Extensions.CreatorStudio.TheExtension).Assembly;
        }
    }
}

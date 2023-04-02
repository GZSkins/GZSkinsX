// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.Runtime.CompilerServices;

using GZSkinsX.Api.Scripting;

using Windows.UI.Xaml;

[assembly: InternalsVisibleTo("GZSkinsX")]

namespace GZSkinsX.Api.Appx;

public static partial class AppxContext
{
    /// <summary>
    /// ��ʼ���������ڷ���
    /// </summary>
    /// <param name="parmas">Ӧ�ó����ʼ���Ĳ���</param>
    /// <param name="serviceLocator"><seealso cref="IServiceLocator"/> �����ʵ��</param>
    /// <exception cref="ArgumentNullException"><paramref name="parmas"/> �� <paramref name="serviceLocator"/> ��Ĭ��ֵΪ��</exception>
    internal static void InitializeLifetimeService(ApplicationInitializationCallbackParams parmas, IServiceLocator serviceLocator)
    {
        if (parmas is null)
        {
            throw new ArgumentNullException(nameof(parmas));
        }

        if (serviceLocator is null)
        {
            throw new ArgumentNullException(nameof(serviceLocator));
        }

        if (s_serviceLocator is not null)
        {
            throw new InvalidOperationException("The lifetime service has been initialized!");
        }

        s_serviceLocator = serviceLocator;
    }
}

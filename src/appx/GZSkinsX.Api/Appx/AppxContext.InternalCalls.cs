// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.Composition.Hosting;
using System.Runtime.CompilerServices;

using Windows.UI.Xaml;

[assembly: InternalsVisibleTo("GZSkinsX")]

namespace GZSkinsX.Api.Appx;

public static partial class AppxContext
{
    /// <summary>
    /// ��ʼ���������ڷ���
    /// </summary>
    /// <param name="parmas">Ӧ�ó����ʼ���Ĳ���</param>
    /// <param name="compositionHost"><seealso cref="CompositionHost"/> �����ʵ��</param>
    /// <exception cref="ArgumentNullException"><paramref name="parmas"/> �� <paramref name="serviceLocator"/> ��Ĭ��ֵΪ��</exception>
    internal static void InitializeLifetimeService(ApplicationInitializationCallbackParams parmas, CompositionHost compositionHost)
    {
        if (parmas is null)
        {
            throw new ArgumentNullException(nameof(parmas));
        }

        if (compositionHost is null)
        {
            throw new ArgumentNullException(nameof(compositionHost));
        }

        if (_compositionHost is not null)
        {
            throw new InvalidOperationException("The lifetime service has been initialized!");
        }

        _compositionHost = compositionHost;
    }
}

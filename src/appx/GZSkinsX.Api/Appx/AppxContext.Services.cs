// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

using GZSkinsX.Api.AccessCache;
using GZSkinsX.Api.Logging;
using GZSkinsX.Api.Scripting;

namespace GZSkinsX.Api.Appx;

public static partial class AppxContext
{
    private static IAppxWindow? s_appxWindow;
    private static IAppxTitleBar? s_appxTitleBar;
    private static IAppxTitleBarButton? s_appxTitleBarButton;
    private static IFutureAccessService? s_futureAccessService;
    private static IMostRecentlyUsedService? s_mostRecentlyUsedService;
    private static ILoggingService? s_loggingService;
    private static IServiceLocator? s_serviceLocator;

    /// <summary>
    /// ��ȡȫ�־�̬����� <see cref="IAppxWindow"/> ʵ��
    /// </summary>
    public static IAppxWindow AppxWindow
    {
        get => CheckAccess(ref s_appxWindow);
    }

    /// <summary>
    /// ��ȡȫ�־�̬����� <see cref="IAppxTitleBar"/> ʵ��
    /// </summary>
    public static IAppxTitleBar AppxTitleBar
    {
        get => CheckAccess(ref s_appxTitleBar);
    }

    /// <summary>
    /// ��ȡȫ�־�̬����� <see cref="IAppxTitleBarButton"/> ʵ��
    /// </summary>
    public static IAppxTitleBarButton AppxTitleBarButton
    {
        get => CheckAccess(ref s_appxTitleBarButton);
    }

    /// <summary>
    /// ��ȡȫ�־�̬����� <see cref="IFutureAccessService"/> ʵ��
    /// </summary>
    public static IFutureAccessService FutureAccessService
    {
        get => CheckAccess(ref s_futureAccessService);
    }

    /// <summary>
    /// ��ȡȫ�־�̬����� <see cref="IMostRecentlyUsedService"/> ʵ��
    /// </summary>
    public static IMostRecentlyUsedService MostRecentlyUsedService
    {
        get => CheckAccess(ref s_mostRecentlyUsedService);
    }

    /// <summary>
    /// ��ȡȫ�־�̬����� <see cref="ILoggingService"/> ʵ��
    /// </summary>
    public static ILoggingService LoggingService
    {
        get => CheckAccess(ref s_loggingService);
    }

    /// <summary>
    /// ��ȡȫ�־�̬����� <see cref="IServiceLocator"/> ʵ��
    /// </summary>
    public static IServiceLocator ServiceLocator
    {
        get => CheckAccess(ref s_serviceLocator);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    private static T CheckAccess<T>([NotNull] ref T? service) where T : class
    {
        if (s_serviceLocator is null)
        {
            throw new InvalidOperationException("The main app is not initialized!");
        }

        return service ??= s_serviceLocator.Resolve<T>();
    }
}

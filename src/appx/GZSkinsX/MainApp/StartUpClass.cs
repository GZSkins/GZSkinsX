// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using GZSkinsX.Extension;
using GZSkinsX.Logging;

using GZSkinsX.SDK.Appx;
using GZSkinsX.SDK.Extension;

using Windows.UI.Xaml;

namespace GZSkinsX.MainApp;

#if DISABLE_XAML_GENERATED_MAIN
/// <summary>
/// �Զ���ĳ���������
/// </summary>
public sealed partial class StartUpClass
{
    /// <summary>
    /// ���ڱ�֤Ӧ�ó����������ڷ���ĳ�ʼ���ͷ��ʵ�ͬ����
    /// </summary>
    private static readonly AutoResetEvent s_synchronouslock;

    /// <summary>
    /// ��ǰ�������������ʵ��
    /// </summary>
    private static readonly CompositionHost s_compositionHost;

    /// <summary>
    /// ��ȡ�ڲ��� <see cref="global::System.Composition.Hosting.CompositionHost"/> ����ʵ��
    /// </summary>
    public static CompositionHost CompositionHost => s_compositionHost;

    /// <summary>
    /// ��ȡ�ڲ��� <see cref="ExtensionService"/> ��̬��Աʵ��
    /// </summary>
    internal static ExtensionService s_extensionService = null!;

    /// <summary>
    /// ��ʼ�� <see cref="StartUpClass"/> �ľ�̬��Ա
    /// </summary>
    static StartUpClass()
    {
        s_synchronouslock = new AutoResetEvent(false);
        var configuration = new ContainerConfiguration();
        configuration.WithAssemblies(GetAssemblies());
        s_compositionHost = configuration.CreateContainer();
    }

    [DebuggerNonUserCode]
    public static void Main(string[] args)
    {
        Application.Start((p) =>
        {
            new App();

            Task.Factory.StartNew(() =>
            {
                InitializeServices(p);
            }).Wait();

            /// ������ǰӦ�ó������߳�
            /// �ȴ��������ڷ����ʼ��
            s_synchronouslock.WaitOne();
        });
    }

    /// <summary>
    /// ���غͳ�ʼ��Ӧ�ó���Ļ�������
    /// </summary>
    /// <param name="parms">Ӧ�ó����ʼ��ʱ�Ĳ���</param>
    [DebuggerNonUserCode]
    private static async void InitializeServices(ApplicationInitializationCallbackParams parms)
    {
        await LoggerImpl.Shared.InitializeAsync();

        AppxContext.InitializeLifetimeService(parms, s_compositionHost);

        s_extensionService = s_compositionHost.GetExport<ExtensionService>();
        s_extensionService.LoadAdvanceExtensions(AdvanceExtensionTrigger.BeforeUniversalExtensions);
        s_extensionService.LoadAdvanceExtensions(AdvanceExtensionTrigger.AfterUniversalExtensions);
        s_extensionService.NotifyUniversalExtensions(UniversalExtensionEvent.Loaded);
        s_extensionService.LoadAdvanceExtensions(AdvanceExtensionTrigger.AfterUniversalExtensionsLoaded);

        s_synchronouslock.Set();
    }


    /// <summary>
    /// ��ȡ��ǰ Appx ���ó���
    /// </summary>
    private static IEnumerable<Assembly> GetAssemblies()
    {
        // Main Appx
        {
            // Self Assembly
            yield return typeof(App).Assembly;
            // GZSkinsX.Api
            yield return typeof(IAppxWindow).Assembly;
        }

        // Extensions
        {
            // GZSkinsX.Extensions.CreatorStudio
            yield return typeof(Extensions.CreatorStudio.TheExtension).Assembly;
        }
    }
}
#endif

// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System.Composition.Hosting;
using System.Diagnostics;

using GZSkinsX.Api.Appx;
using GZSkinsX.Api.Extension;
using GZSkinsX.Extension;
using GZSkinsX.Logging;

using Windows.UI.Xaml;

namespace GZSkinsX.MainApp;

#if DISABLE_XAML_GENERATED_MAIN
/// <summary>
/// �Զ���ĳ���������
/// </summary>
public sealed partial class StartUpClass
{
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
        var configuration = new ContainerConfiguration();
        configuration.WithAssemblies(GetAssemblies());
        s_compositionHost = configuration.CreateContainer();
    }

    [DebuggerNonUserCode]
    public static void Main(string[] args)
    {
        Application.Start((p) => InitializeServices(p, new App()));
    }

    /// <summary>
    /// ���غͳ�ʼ��Ӧ�ó���Ļ�������
    /// </summary>
    /// <param name="parms">Ӧ�ó����ʼ��ʱ�Ĳ���</param>
    /// <param name="mainApp">���ڳ�ʼ����Ӧ�ó���</param>
    [DebuggerNonUserCode]
    private static async void InitializeServices(ApplicationInitializationCallbackParams parms, App mainApp)
    {
        await LoggerImpl.Shared.InitializeAsync();

        AppxContext.InitializeLifetimeService(parms, s_compositionHost);

        s_extensionService = s_compositionHost.GetExport<ExtensionService>();
        s_extensionService.LoadAdvanceExtensions(AdvanceExtensionTrigger.BeforeUniversalExtensions);
        s_extensionService.LoadAdvanceExtensions(AdvanceExtensionTrigger.AfterUniversalExtensions);
        s_extensionService.NotifyUniversalExtensions(UniversalExtensionEvent.Loaded);
        s_extensionService.LoadAdvanceExtensions(AdvanceExtensionTrigger.AfterUniversalExtensionsLoaded);
    }
}
#endif

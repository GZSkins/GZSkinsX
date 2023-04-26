// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Composition.Hosting;
using System.Diagnostics;

using GZSkinsX.Api.Appx;
using GZSkinsX.Api.Extension;
using GZSkinsX.Api.Scripting;
using GZSkinsX.Extension;
using GZSkinsX.Logging;

using Microsoft.UI.Xaml.Controls;

using Windows.System;
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

        // �ⲿ�ֿ��ܿ�����Щ��Ť������������Ȼ�ȡ����
        // �� ExtensionService��Ȼ��ʼ�����־��Ϣ
        var extensionService = s_compositionHost.GetExport<ExtensionService>();
        var serviceLocator = s_compositionHost.GetExport<IServiceLocator>();
        AppxContext.InitializeLifetimeService(parms, serviceLocator);
        extensionService.LoadAutoLoaded(AutoLoadedType.BeforeExtensions);

        // �ϲ���չ�������Դ�ֵ�����������
        var xamlControlsResources = new XamlControlsResources();
        var mergedResourceDictionaries = xamlControlsResources.MergedDictionaries;
        foreach (var rsrc in extensionService.GetMergedResourceDictionaries())
        {
            mergedResourceDictionaries.Add(rsrc);
        }

        // �޸� XamlControlsResources ���ʳ�ͻ���쳣
        var dispatcherQueue = DispatcherQueue.GetForCurrentThread();
        if (dispatcherQueue.HasThreadAccess)
        {
            dispatcherQueue.TryEnqueue(() =>
            {
                mainApp.Resources = xamlControlsResources;
            });
        }

        extensionService.LoadAutoLoaded(AutoLoadedType.AfterExtensions);
        extensionService.NotifyExtensions(ExtensionEvent.Loaded);
        extensionService.LoadAutoLoaded(AutoLoadedType.AfterExtensionsLoaded);
    }
}
#endif

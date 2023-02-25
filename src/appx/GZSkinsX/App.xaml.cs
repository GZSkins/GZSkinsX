﻿// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

using GZSkinsX.Api.Appx;

using GZSkinsX.Api.Extension;
using GZSkinsX.Api.WindowManager;
using GZSkinsX.Composition;
using GZSkinsX.Extension;
using GZSkinsX.WindowManager;

using Microsoft.VisualStudio.Composition;

using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace GZSkinsX;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
sealed partial class App : Application
{
    private ExportProvider? _exportProvider;

    private IAppxWindow? _appxWindow;

    private IWindowManagerServiceImpl? _windowManagerService;

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeComponent();
        Suspending += OnSuspending;
    }

    /// <summary>
    /// Invoked when Navigation to a certain page fails
    /// </summary>
    /// <param name="sender">The Frame which failed navigation</param>
    /// <param name="e">Details about the navigation failure</param>
    void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
        throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
    }

    /// <summary>
    /// Invoked when application execution is being suspended.  Application state is saved
    /// without knowing whether the application will be terminated or resumed with the contents
    /// of memory still intact.
    /// </summary>
    /// <param name="sender">The source of the suspend request.</param>
    /// <param name="e">Details about the suspend request.</param>
    private void OnSuspending(object sender, SuspendingEventArgs e)
    {
        var deferral = e.SuspendingOperation.GetDeferral();
        //TODO: Save application state and stop any background activity
        deferral.Complete();
    }

    /// <summary>
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="e">Details about the launch request and process.</param>
    protected override async void OnLaunched(LaunchActivatedEventArgs e)
    {
        _exportProvider ??= await InitializeMEF();
        _appxWindow ??= _exportProvider.GetExportedValue<IAppxWindow>();
        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
            //TODO: Load state from previously suspended application
        }

        if (e.PrelaunchActivated == false)
        {
            _windowManagerService ??= _exportProvider.GetExportedValue<IWindowManagerServiceImpl>();
            if (_windowManagerService.Frame.Content is null)
            {
                _windowManagerService.NavigateTo(ViewElementConstants.StartUpPage_Guid);
            }

            _appxWindow.Activate();
        }
    }

    private async Task<ExportProvider> InitializeMEF()
    {
        var catalog = new AssemblyCatalogV2().AddParts(GetAssemblies());
        var container = new CompositionContainerV2(catalog);
        var exportProvider = await container.CreateExportProviderAsync("mefv2.bin");

        InitializeServices(exportProvider);
        return exportProvider;
    }

    /// <summary>
    /// 初始化应用程序核心服务
    /// </summary>
    /// <param name="exportProvider"><see cref="ExportProvider"/> 对象的实例</param>
    private void InitializeServices(ExportProvider exportProvider)
    {
        //var serviceLocator = exportProvider.GetExportedValue<ServiceLocator>();
        //serviceLocator.SetExportProvider(exportProvider);

        InitializeExtension(exportProvider.GetExportedValue<ExtensionService>());
    }

    /// <summary>
    /// 初始化应用程序扩展组件
    /// </summary>
    /// <param name="extensionService">扩展服务实例</param>
    private void InitializeExtension(ExtensionService extensionService)
    {
        extensionService.LoadAutoLoaded(AutoLoadedType.BeforeExtensions);
        foreach (var rsrc in extensionService.GetMergedResourceDictionaries())
        {
            Resources.MergedDictionaries.Add(rsrc);
        }

        extensionService.LoadAutoLoaded(AutoLoadedType.AfterExtensions);
        extensionService.NotifyExtensions(ExtensionEvent.Loaded);
        extensionService.LoadAutoLoaded(AutoLoadedType.AfterExtensionsLoaded);
    }

    /// <summary>
    /// 获取当前 Appx 引用程序集
    /// </summary>
    private static IEnumerable<Assembly> GetAssemblies()
    {
        // Self Assembly
        yield return typeof(App).Assembly;
        // GZSkinsX.Api
        yield return typeof(IAppxWindow).Assembly;
        // GZSkinsX.Appx.StartUp
        yield return typeof(Appx.StartUp.AppxStartUp).Assembly;
    }
}

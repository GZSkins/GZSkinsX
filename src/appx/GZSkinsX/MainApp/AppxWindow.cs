// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.Composition;

using GZSkinsX.Api.Appx;
using GZSkinsX.Api.Extension;
using GZSkinsX.Extension;

using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace GZSkinsX.MainApp;

/// <summary>
/// ������Ӧ�ô����࣬���ڹ����������Լ�ע��������
/// </summary>
[Shared, Export(typeof(IAppxWindow))]
internal sealed class AppxWindow : IAppxWindow
{
    /// <summary>
    /// ��ǰӦ�ó������չ������Ҫ������ OnAppLoaded �¼��ж��Ѽ��ص���չ����֪ͨ AppLoaded �¼�
    /// </summary>
    private readonly ExtensionService _extensionService;

    /// <summary>
    /// ��ǰӦ������ͼʵ��
    /// </summary>
    private readonly ApplicationView _currentAppView;

    /// <summary>
    /// ��ǰӦ�ó���������ʵ��
    /// </summary>
    private readonly Window _shellWindow;

    /// <inheritdoc/>
    public ApplicationView ApplicationView => _currentAppView;

    /// <inheritdoc/>
    public Window MainWindow => _shellWindow;

    /// <inheritdoc/>
    public event EventHandler<WindowActivatedEventArgs>? Activated;

    /// <inheritdoc/>
    public event EventHandler<WindowActivatedEventArgs>? Deactivated;

    /// <inheritdoc/>
    public event EventHandler? Closed;

    /// <summary>
    /// ��ʼ�� <see cref="AppxWindow"/> ����ʵ��
    /// </summary>
    /// <param name="extensionService">Ӧ�ó�����չ����</param>
    [ImportingConstructor]
    public AppxWindow(ExtensionService extensionService)
    {
        _extensionService = extensionService;
        _currentAppView = ApplicationView.GetForCurrentView();

        _shellWindow = Window.Current;
        _shellWindow.Activated += OnActivated;
        _shellWindow.Closed += OnClosed;

        Activated += OnAppLoaded;
    }

    private void InitializeUIElement()
    {
#if DEBUG
        _currentAppView.Title = "DEBUG";
#endif
    }

    /// <summary>
    /// ������Ѽ��ص�Ӧ�ó�����չ֪ͨ AppLoaded �¼�
    /// </summary>
    private void OnAppLoaded(object? sender, WindowActivatedEventArgs e)
    {
        Activated -= OnAppLoaded;
        InitializeUIElement();

        _extensionService.NotifyExtensions(ExtensionEvent.AppLoaded);
        _extensionService.LoadAutoLoaded(AutoLoadedType.AppLoaded);
    }

    /// <summary>
    /// ��ǰӦ�ó��������ڵļ����¼�
    /// </summary>
    private void OnActivated(object sender, WindowActivatedEventArgs args)
    {
        if (args.WindowActivationState == CoreWindowActivationState.Deactivated)
        {
            Deactivated?.Invoke(this, args);
        }
        else
        {
            Activated?.Invoke(this, args);
        }
    }

    /// <summary>
    /// ��ǰӦ�ó��������ڵĹر��¼�
    /// </summary>
    private void OnClosed(object sender, CoreWindowEventArgs args)
    {
        _extensionService.NotifyExtensions(ExtensionEvent.AppExit);
        Closed?.Invoke(this, new EventArgs());
    }

    /// <inheritdoc/>
    public void Activate()
    => MainWindow.Activate();

    /// <inheritdoc/>
    public void Close()
    => MainWindow.Close();
}

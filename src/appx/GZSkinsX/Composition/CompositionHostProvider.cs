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
using System.Reflection;

using GZSkinsX.Api.Appx;

namespace GZSkinsX.Composition;

/// <summary>
/// һ��������������࣬�����ṩ������ <see cref="global::System.Composition.Hosting.CompositionHost"/> ��ʵ��
/// </summary>
internal sealed class CompositionHostProvider
{
    /// <summary>
    /// ������������ֻ�е���ȡʱ�Żᴴ��Ŀ������
    /// </summary>
    private static readonly Lazy<CompositionHostProvider> s_lazy = new(() => new());

    /// <summary>
    /// ȫ�־�̬ <see cref="CompositionHostProvider"/> ��ʵ����������ܴ�����ֻ����һ��ʵ��
    /// </summary>
    public static CompositionHostProvider Instance => s_lazy.Value;

    /// <summary>
    /// ��ǰ�������������ʵ��
    /// </summary>
    private readonly CompositionHost _compositionHost;

    /// <summary>
    /// ��ȡ��ǰ�����������ʵ��
    /// </summary>
    public CompositionHost CompositionHost => _compositionHost;

    /// <summary>
    /// ��ʼ�� <see cref="CompositionHostProvider"/> ����ʵ��
    /// </summary>
    private CompositionHostProvider()
    {
        var configuration = new ContainerConfiguration();
        configuration.WithAssemblies(GetAssemblies());
        _compositionHost = configuration.CreateContainer();
    }

    /// <summary>
    /// ��ȡ��ǰ Appx ���ó���
    /// </summary>
    private static IEnumerable<Assembly> GetAssemblies()
    {
        // Self Assembly
        yield return typeof(App).Assembly;
        // GZSkinsX.Api
        yield return typeof(IAppxWindow).Assembly;
        // GZSkinsX.Appx.Navigation
        yield return typeof(Appx.Navigation.AppxNavigation).Assembly;
        // GZSkinsX.Appx.Preload
        yield return typeof(Appx.Preload.AppxPreload).Assembly;
        // GZSkinsX.Appx.StartUp
        yield return typeof(Appx.StartUp.AppxStartUp).Assembly;
    }
}

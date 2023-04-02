// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System.Composition;
using System.Composition.Hosting;
using System.Diagnostics.CodeAnalysis;

using GZSkinsX.Api.Scripting;

namespace GZSkinsX.Scripting;

/// <inheritdoc cref="IServiceLocator"/>
[Shared, Export(typeof(IServiceLocator))]
internal sealed class ServiceLocator : IServiceLocator
{
    /// <summary>
    /// ���ڻ�ȡ�ѵ��������͵��������
    /// </summary>
    private readonly CompositionHost _compositionHost;

    /// <summary>
    /// ��ʼ�� <see cref="ServiceLocator"/> ����ʵ��
    /// </summary>
    public ServiceLocator()
    {
        _compositionHost = Program.CompositionHost;
    }

    /// <inheritdoc/>
    public T Resolve<T>() where T : class
    => _compositionHost.GetExport<T>();

    /// <inheritdoc/>
    public bool TryResolve<T>([NotNullWhen(true)] out T? value) where T : class
    => _compositionHost.TryGetExport<T>(out value);
}

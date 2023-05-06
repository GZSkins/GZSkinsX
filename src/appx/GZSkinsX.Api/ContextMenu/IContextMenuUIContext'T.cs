// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace GZSkinsX.Api.ContextMenu;

/// <summary>
/// ���ڱ�ʾ�����Ĳ˵����������� UI ������
/// </summary>
/// <typeparam name="T1">ָ�� <see cref="UIObject"/> ������</typeparam>
/// <typeparam name="T2">ָ�� <see cref="Parameter"/> ������</typeparam>
public interface IContextMenuUIContext<T1, T2> : IContextMenuUIContext
{
    /// <inheritdoc cref="IContextMenuUIContext.UIObject"/>
    new T1 UIObject { get; }

    /// <inheritdoc cref="IContextMenuUIContext.Parameter"/>
    new T2 Parameter { get; }
}

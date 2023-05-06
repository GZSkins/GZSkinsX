// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using Windows.UI.Xaml.Controls;

namespace GZSkinsX.Api.ContextMenu;

/// <summary>
/// ��ʾ������ <see cref="IContextToggleMenuItem"/> �ĳ�����࣬���ṩ�����Ľӿڳ�Աʵ��
/// </summary>
/// <typeparam name="TContext">Ŀ�� UI �����ĵĲ�������</typeparam>
public abstract class ContextToggleMenuItemBase<TContext> : IContextToggleMenuItem
    where TContext : IContextMenuUIContext
{
    /// <inheritdoc/>
    public string? Header { get; protected set; }

    /// <inheritdoc/>
    public IconElement? Icon { get; protected set; }

    /// <inheritdoc/>
    public ContextMenuItemShortcutKey? ShortcutKey { get; protected set; }

    /// <inheritdoc/>
    public object? ToolTip { get; protected set; }

    /// <inheritdoc cref="IContextToggleMenuItem.IsChecked(IContextMenuUIContext)"/>
    public virtual bool IsChecked(TContext context) => false;

    /// <inheritdoc cref="IContextMenuItem.IsEnabled(IContextMenuUIContext)"/>
    public virtual bool IsEnabled(TContext context) => true;

    /// <inheritdoc cref="IContextMenuItem.IsVisible(IContextMenuUIContext)"/>
    public virtual bool IsVisible(TContext context) => true;

    /// <inheritdoc cref="IContextMenuItem.OnExecute(IContextMenuUIContext)"/>
    public virtual void OnExecute(TContext context) { }

    /// <inheritdoc cref="IContextToggleMenuItem.OnToggle(bool, IContextMenuUIContext)"/>
    public virtual void OnToggle(bool newValue, TContext context) { }

    /// <inheritdoc/>
    void IContextMenuItem.OnExecute(IContextMenuUIContext ctx) => OnExecute((TContext)ctx);

    /// <inheritdoc/>
    bool IContextToggleMenuItem.IsChecked(IContextMenuUIContext context) => IsChecked((TContext)context);

    /// <inheritdoc/>
    bool IContextMenuItem.IsEnabled(IContextMenuUIContext ctx) => IsEnabled((TContext)ctx);

    /// <inheritdoc/>
    bool IContextMenuItem.IsVisible(IContextMenuUIContext ctx) => IsVisible((TContext)ctx);

    /// <inheritdoc/>
    void IContextToggleMenuItem.OnToggle(bool newValue, IContextMenuUIContext context) => OnToggle(newValue, (TContext)context);
}

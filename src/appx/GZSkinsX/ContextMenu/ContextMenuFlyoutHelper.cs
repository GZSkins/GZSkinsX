// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using GZSkinsX.SDK.ContextMenu;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GZSkinsX.ContextMenu;

/// <summary>
/// ��ʾΪ <see cref="MenuFlyout"/> �İ����࣬���ڻ�ȡ�������Զ���ĸ�������
/// </summary>
internal sealed class ContextMenuFlyoutHelper
{
    /// <summary>
    /// ���� CoerceValueCallback �ĸ�����������
    /// </summary>
    public static readonly DependencyProperty CoerceValueCallbackProperty =
        DependencyProperty.RegisterAttached("CoerceValueCallback", typeof(CoerceContextMenuUIContextCallback),
            typeof(ContextMenuFlyoutHelper), new PropertyMetadata(null));

    /// <summary>
    /// ��ȡָ�������е� <see cref="CoerceValueCallbackProperty"/> �������Ե�ֵ
    /// </summary>
    public static CoerceContextMenuUIContextCallback? GetCoerceValueCallback(DependencyObject obj)
    => (CoerceContextMenuUIContextCallback)obj.GetValue(CoerceValueCallbackProperty);

    /// <summary>
    /// ��ָ���Ķ������� <see cref="CoerceValueCallbackProperty"/> �������Ե�ֵ
    /// </summary>
    public static void SetCoerceValueCallback(DependencyObject obj, CoerceContextMenuUIContextCallback? value)
    => obj.SetValue(CoerceValueCallbackProperty, value);
}

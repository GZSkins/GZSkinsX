// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace GZSkinsX.Api.ContextMenu;

/// <summary>
/// ��ʾ�ڴ��������Ĳ˵�ʱ��ѡ��������
/// </summary>
[ContractVersion(typeof(UniversalApiContract), 65536u)]
public sealed class ContextMenuOptions
{
    /// <summary>
    /// ��ʾ���û���Ԫ�ؽ���ʱ�Ƿ��Զ���ȡ���㡣
    /// </summary>
    [ContractVersion(typeof(UniversalApiContract), 196608u)]
    public bool AllowFocusOnInteraction { get; set; }

    /// <summary>
    /// ��ʾ�ؼ��ڽ���ʱ�Ƿ���Խ��ս���
    /// </summary>
    [ContractVersion(typeof(UniversalApiContract), 196608u)]
    public bool AllowFocusWhenDisabled { get; set; }

    /// <summary>
    /// ��ʾ�ڸ����ؼ��򿪻�ر�ʱ�Ƿ񲥷Ŷ���
    /// </summary>
    [ContractVersion(typeof(UniversalApiContract), 458752u)]
    public bool AreOpenCloseAnimationsEnabled { get; set; }

    /// <summary>
    /// ��ʾ�Ƿ� ǳɫ���� UI �ⲿ������䰵
    /// </summary>
    [ContractVersion(typeof(UniversalApiContract), 196608u)]
    public LightDismissOverlayMode LightDismissOverlayMode { get; set; }

    /// <summary>
    /// �����ڳ��� MenuFlyout ʱʹ�õ���ʽ
    /// </summary>
    [ContractVersion(typeof(UniversalApiContract), 65536u)]
    public Style? MenuFlyoutPresenterStyle { get; set; }

    /// <summary>
    /// ����һ��Ԫ�أ���Ԫ��Ӧ����ָ�������¼�����ʹ�����ؼ�����֮��Ҳ�����
    /// </summary>
    [ContractVersion(typeof(UniversalApiContract), 262144u)]
    public DependencyObject? OverlayInputPassThroughElement { get; set; }

    /// <summary>
    /// ����Ҫ���ڸ����ؼ���Ĭ��λ�ã�����������Ŀ��
    /// </summary>
    [ContractVersion(typeof(UniversalApiContract), 65536u)]
    public FlyoutPlacementMode Placement { get; set; }

    /// <summary>
    /// ��ʾ�Ƿ�Ӧ�� XAML ���ı߽�����ʾ�����ؼ�
    /// </summary>
    [ContractVersion(typeof(UniversalApiContract), 524288u)]
    public bool ShouldConstrainToRootBounds { get; set; }

    /// <summary>
    /// ��ʾ�����ؼ�����ʾʱ����Ϊ��ʽ
    /// </summary>
    [ContractVersion(typeof(UniversalApiContract), 458752u)]
    public FlyoutShowMode ShowMode { get; set; }

    /// <summary>
    /// ��ʼ�� <see cref="ContextMenuOptions"/> ����ʵ��
    /// </summary>
    public ContextMenuOptions()
    {
        AllowFocusOnInteraction = true;
        AreOpenCloseAnimationsEnabled = true;
        LightDismissOverlayMode = LightDismissOverlayMode.Auto;
        Placement = FlyoutPlacementMode.Top;
        ShowMode = FlyoutShowMode.Standard;
    }
}

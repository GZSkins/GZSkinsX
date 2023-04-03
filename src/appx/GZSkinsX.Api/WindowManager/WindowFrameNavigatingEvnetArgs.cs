// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using Windows.UI.Xaml.Media.Animation;

namespace GZSkinsX.Api.WindowManager;

/// <summary>
/// ��ʾ�� <see cref="IWindowManagerService"/> �н��е���ʱ���õ����¼�����
/// </summary>
public sealed class WindowFrameNavigatingEvnetArgs
{
    /// <summary>
    /// ��ȡ��ǰ�����������������Ϣ
    /// </summary>
    public IWindowFrameContext Context { get; }

    /// <summary>
    /// ��ȡ�����õ�����Ŀ��ҳ�������ݵĲ���
    /// </summary>
    public object? Parameter { get; set; }

    /// <summary>
    /// ��ȡ�������ڵ���ʱ����ҳ����ɵ��л���������
    /// </summary>
    public NavigationTransitionInfo? NavigationTransitionInfo { get; set; }

    /// <summary>
    /// ��ʼ�� <see cref="WindowFrameNavigatingEvnetArgs"/> ����ʵ��
    /// </summary>
    public WindowFrameNavigatingEvnetArgs(
        IWindowFrameContext context, object? parameter,
        NavigationTransitionInfo? navigationTransitionInfo)
    {
        Context = context;
        Parameter = parameter;
        NavigationTransitionInfo = navigationTransitionInfo;
    }
}

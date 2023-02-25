// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;

using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace GZSkinsX.Api.Appx;

/// <summary>
/// �ṩӦ�ó��������ڵ��¼����Լ����ڹ�����ص� Api
/// </summary>
public interface IAppxWindow
{
    /// <summary>
    /// ��ǰӦ������ͼ
    /// </summary>
    ApplicationView ApplicationView { get; }

    /// <summary>
    /// ��ǰӦ�ó���������
    /// </summary>
    Window MainWindow { get; }

    /// <summary>
    /// ���ǰӦ�ó���������
    /// </summary>
    void Activate();

    /// <summary>
    /// �رյ�ǰӦ�ó���������
    /// </summary>
    void Close();

    /// <summary>
    /// ��Ӧ�ó��������ڱ�����ʱ����
    /// </summary>
    event EventHandler<WindowActivatedEventArgs>? Activated;

    /// <summary>
    /// ��Ӧ�ó��������ڱ���Ϊ��̨����ʱ����
    /// </summary>
    event EventHandler<WindowActivatedEventArgs>? Deactivated;

    /// <summary>
    /// ��Ӧ�ó��������ڹر�֮�󴥷�
    /// </summary>
    event EventHandler? Closed;
}

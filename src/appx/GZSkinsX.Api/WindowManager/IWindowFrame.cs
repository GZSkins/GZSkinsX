// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Threading.Tasks;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GZSkinsX.Api.WindowManager;

/// <summary>
/// ��ʾλ��Ӧ�ó����������е�ҳ��Ԫ�أ�ͨ���������������ڽ���ҳ���л�
/// </summary>
public interface IWindowFrame
{
    /// <summary>
    /// ���뿪��ǰҳ��ʱ���������ڴ˽���ȡ���¼�ע�����ز���
    /// </summary>
    Task OnNavigateFromAsync();

    /// <summary>
    /// �ڵ�����Ŀ��ҳ��ʱ�������ɶ�Ŀ��ҳ�����Խ��и��ļ�����
    /// </summary>
    /// <param name="args"><seealso cref="Frame"/> �ĵ����¼�����</param>
    Task OnNavigateToAsync(NavigationEventArgs args);

    /// <summary>
    /// �ڽ��뵼������ʱ���������ڵ�����Ŀ��ҳ��ǰ������ز���
    /// </summary>
    /// <param name="args">�������¼�����</param>
    Task OnNavigatingAsync(WindowFrameNavigateEventArgs args);
}

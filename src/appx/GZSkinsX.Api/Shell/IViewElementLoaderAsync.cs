// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Threading.Tasks;

using Windows.UI.Xaml.Controls;

namespace GZSkinsX.Api.Shell;

/// <summary>
/// ��ʾ��ҳ����г�ʼ���Ȳ�����һ���м����
/// </summary>
public interface IViewElementLoaderAsync : IViewElement
{
    /// <summary>
    /// �ڽ��뵼������ʱ���������ڵ�����Ŀ��ҳ��ǰ������ز���
    /// </summary>
    /// <param name="args">�������¼�����</param>
    Task OnNavigatingAsync(WindowFrameNavigateEventArgs args);

    /// <summary>
    /// ��ҳ���ʼ��ʱ�������ɶ�Ŀ��ҳ�����Խ��и��ļ�����
    /// </summary>
    /// <param name="viewElement">Ŀ����ͼ����</param>
    Task OnInitializeAsync(Page viewElement);
}

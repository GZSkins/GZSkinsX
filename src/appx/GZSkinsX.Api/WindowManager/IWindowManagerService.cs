// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;

using Windows.UI.Xaml.Media.Animation;

namespace GZSkinsX.Api.WindowManager;

/// <summary>
/// �ṩ�Ե�ǰӦ�ó����������е�ҳ����л�/����������
/// </summary>
public interface IWindowManagerService
{
    /// <summary>
    /// ���������ʶ��ƥ���ָ��ҳ��
    /// </summary>
    /// <param name="guidString">��ͼ����� <see cref="Guid"/> ���ַ���ֵ</param>
    void NavigateTo(string guidString);

    /// <summary>
    /// ���������ʶ��ƥ���ָ��ҳ�棬�����ݵ�������
    /// </summary>
    /// <param name="guidString">��ͼ����� <see cref="Guid"/> ���ַ���ֵ</param>
    /// <param name="parameter">���ݸ�Ŀ��ҳ��Ĳ���</param>
    void NavigateTo(string guidString, object parameter);

    /// <summary>
    /// ���������ʶ��ƥ���ָ��ҳ�棬�����ݵ���������ָ������ҳ���л�Ч��
    /// </summary>
    /// <param name="guidString">��ͼ����� <see cref="Guid"/> ���ַ���ֵ</param>
    /// <param name="parameter">���ݸ�Ŀ��ҳ��Ĳ���</param>
    /// <param name="infoOverride"></param>
    void NavigateTo(string guidString, object parameter, NavigationTransitionInfo infoOverride);

    /// <summary>
    /// ���������ʶ��ƥ���ָ��ҳ��
    /// </summary>
    /// <param name="frameGuid">��ͼ����� <see cref="Guid"/> ֵ</param>
    void NavigateTo(Guid frameGuid);

    /// <summary>
    /// ���������ʶ��ƥ���ָ��ҳ�棬�����ݵ�������
    /// </summary>
    /// <param name="frameGuid">��ͼ����� <see cref="Guid"/> ֵ</param>
    /// <param name="parameter">���ݸ�Ŀ��ҳ��Ĳ���</param>
    void NavigateTo(Guid frameGuid, object parameter);

    /// <summary>
    /// ���������ʶ��ƥ���ָ��ҳ�棬�����ݵ���������ָ������ҳ���л�Ч��
    /// </summary>
    /// <param name="frameGuid">��ͼ����� <see cref="Guid"/> ֵ</param>
    /// <param name="parameter">���ݸ�Ŀ��ҳ��Ĳ���</param>
    /// <param name="infoOverride"></param>
    void NavigateTo(Guid frameGuid, object parameter, NavigationTransitionInfo infoOverride);
}

// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;

using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace GZSkinsX.Api.Navigation;

/// <summary>
/// 
/// </summary>
public interface INavigationService
{
    /// <summary>
    /// 
    /// </summary>
    event NavigatedEventHandler? Navigated;

    /// <summary>
    /// 
    /// </summary>
    bool CanGoBack { get; }

    /// <summary>
    /// 
    /// </summary>
    bool CanGoForward { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    bool GoBack();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    bool GoForward();

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
    /// <param name="navItemGuid">��ͼ����� <see cref="Guid"/> ֵ</param>
    void NavigateTo(Guid navItemGuid);

    /// <summary>
    /// ���������ʶ��ƥ���ָ��ҳ�棬�����ݵ�������
    /// </summary>
    /// <param name="navItemGuid">��ͼ����� <see cref="Guid"/> ֵ</param>
    /// <param name="parameter">���ݸ�Ŀ��ҳ��Ĳ���</param>
    void NavigateTo(Guid navItemGuid, object parameter);

    /// <summary>
    /// ���������ʶ��ƥ���ָ��ҳ�棬�����ݵ���������ָ������ҳ���л�Ч��
    /// </summary>
    /// <param name="navItemGuid">��ͼ����� <see cref="Guid"/> ֵ</param>
    /// <param name="parameter">���ݸ�Ŀ��ҳ��Ĳ���</param>
    /// <param name="infoOverride"></param>
    void NavigateTo(Guid navItemGuid, object parameter, NavigationTransitionInfo infoOverride);
}

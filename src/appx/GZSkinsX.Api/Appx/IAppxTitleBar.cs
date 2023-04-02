// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

namespace GZSkinsX.Api.Appx;

/// <summary>
/// �ṩ�Ե�ǰ���ڱ��������������
/// </summary>
public interface IAppxTitleBar
{
    /// <summary>
    /// ��ȡ�������Ƿ񽫵�ǰ�����е�������ͼ��չ��������
    /// </summary>
    bool ExtendViewIntoTitleBar { get; set; }

    /// <summary>
    /// ���õ�ǰ���ڱ������Ľ���Ԫ��
    /// </summary>
    /// <param name="value">��Ҫ��Ϊ�������� UI Ԫ��</param>
    void SetTitleBar(Windows.UI.Xaml.UIElement? value);
}

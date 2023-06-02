// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

namespace GZSkinsX.SDK.ContextMenu;

/// <summary>
/// ��ʾ��������������ѡ�˵����Ĳ˵���
/// </summary>
public interface IContextRadioMenuItem : IContextMenuItem
{
    /// <summary>
    /// ��ȡ�˲˵����������˵������������
    /// </summary>
    string? GroupName { get; }

    /// <summary>
    /// ͨ����ǰ UI �������жϵ�ǰ�˵����Ƿ�Ϊѡ��״̬
    /// </summary>
    /// <param name="context">�뵱ǰ�����Ĳ˵��������� UI ����������</param>
    /// <returns>������� true ���ʾΪѡ��״̬�����򽫱�ʾΪδѡ�е�״̬</returns>
    bool IsChecked(IContextMenuUIContext context);

    /// <summary>
    /// ��ʾ�˵����Ĭ�ϵ����Ϊ
    /// </summary>
    /// <param name="isChecked">��ʾ�Ƿ�Ϊѡ��״̬</param>
    /// <param name="context">�뵱ǰ�����Ĳ˵��������� UI ����������</param>
    void OnClick(bool isChecked, IContextMenuUIContext context);
}

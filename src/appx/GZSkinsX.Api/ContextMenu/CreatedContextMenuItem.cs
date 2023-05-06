// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace GZSkinsX.Api.ContextMenu;

/// <summary>
/// ��ʾΪͨ���Զ��崴���������Ĳ˵���
/// </summary>
public readonly struct CreatedContextMenuItem
{
    /// <summary>
    /// ��ȡ�������Ĳ˵����Ԫ����
    /// </summary>
    public ContextMenuItemMetadataAttribute? Metadata { get; }

    /// <summary>
    /// ��ȡ�������Ĳ˵���
    /// </summary>
    public IContextMenuItem? ContextMenuItem { get; }

    /// <summary>
    /// ���ڱ�ʾ��ǰ�ṹ���еĳ�Ա�Ƿ�δ�������캯����ֵ������Ϊ��
    /// </summary>
    [MemberNotNullWhen(false, nameof(Metadata), nameof(ContextMenuItem))]
    public bool IsEmpty { get; }

    /// <summary>
    /// ��ʼ�� <see cref="CreatedContextMenuItem"/> ����ʵ��
    /// </summary>
    public CreatedContextMenuItem()
    {
        IsEmpty = true;
    }

    /// <summary>
    /// ��ʼ�� <see cref="CreatedContextMenuItem"/> ����ʵ��
    /// </summary>
    /// <param name="metadata">�������Ĳ˵�����������Ԫ����</param>
    /// <param name="contextMenuItem">�����Ĳ˵��������ʵ�ֵ�ʵ��</param>
    public CreatedContextMenuItem(ContextMenuItemMetadataAttribute metadata, IContextMenuItem contextMenuItem)
    {
        Metadata = metadata;
        ContextMenuItem = contextMenuItem;
    }
}

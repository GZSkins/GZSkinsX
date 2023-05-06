// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Collections.Generic;

namespace GZSkinsX.ContextMenu;

/// <summary>
/// ���ڴ洢�Ӳ˵���������������Ϣ
/// </summary>
internal sealed class ContextItemGroupContext
{
    /// <summary>
    /// ��ȡ���������
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// ��ȡ���������˳��
    /// </summary>
    public double Order { get; }

    /// <summary>
    /// ��ȡ�����е��Ӳ˵���
    /// </summary>
    public List<ContextMenuItemContext> Items { get; }

    /// <summary>
    /// ��ʼ�� <see cref="ContextItemGroupContext"/> ����ʵ��
    /// </summary>
    public ContextItemGroupContext(string name, double order)
    {
        Name = name;
        Order = order;
        Items = new List<ContextMenuItemContext>();
    }
}

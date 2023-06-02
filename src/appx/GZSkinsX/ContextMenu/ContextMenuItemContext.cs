// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;

using GZSkinsX.SDK.ContextMenu;

namespace GZSkinsX.ContextMenu;

/// <summary>
/// ���ڴ洢������ <see cref="IContextMenuItem"/> �����Լ� <see cref="ContextMenuItemMetadataAttribute"/> Ԫ����
/// </summary>
internal sealed class ContextMenuItemContext
{
    /// <summary>
    /// ��ǰ�������е������ض���
    /// </summary>
    private readonly Lazy<IContextMenuItem, ContextMenuItemMetadataAttribute> _lazy;

    /// <summary>
    /// ��ȡ��ǰ�����ĵ� <see cref="IContextMenuItem"/> ����
    /// </summary>
    public IContextMenuItem Value => _lazy.Value;

    /// <summary>
    /// ��ȡ��ǰ�����ĵ� <see cref="ContextMenuItemMetadataAttribute"/> Ԫ����
    /// </summary>
    public ContextMenuItemMetadataAttribute Metadata => _lazy.Metadata;

    /// <summary>
    /// ��ʼ�� <see cref="ContextMenuItemContext"/> ����ʵ��
    /// </summary>
    public ContextMenuItemContext(Lazy<IContextMenuItem, ContextMenuItemMetadataAttribute> lazy)
    {
        _lazy = lazy;
    }
}

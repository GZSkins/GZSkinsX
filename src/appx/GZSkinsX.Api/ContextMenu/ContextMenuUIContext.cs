// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace GZSkinsX.SDK.ContextMenu;

/// <summary>
/// ��ʾ������ <see cref="IContextMenuUIContext"/> ��Ĭ��ʵ��
/// </summary>
public class ContextMenuUIContext : IContextMenuUIContext
{
    /// <inheritdoc/>
    public object UIObject { get; }

    /// <inheritdoc/>
    public object Parameter { get; }

    /// <summary>
    /// ��ʼ�� <see cref="ContextMenuUIContext"/> ����ʵ��
    /// </summary>
    /// <param name="uiObject">ָ����ǰ UI �������е� UI ����</param>
    /// <param name="parameter">ָ����ǰ UI �������еĲ���</param>
    public ContextMenuUIContext(object uiObject, object parameter)
    {
        UIObject = uiObject;
        Parameter = parameter;
    }
}

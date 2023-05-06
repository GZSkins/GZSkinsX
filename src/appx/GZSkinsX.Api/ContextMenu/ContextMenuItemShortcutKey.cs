// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Windows.System;

namespace GZSkinsX.Api.ContextMenu;

/// <summary>
/// ���ڱ�ʾ�����Ĳ˵�����ָ���Ŀ�ݼ�
/// </summary>
public sealed class ContextMenuItemShortcutKey
{
    /// <summary>
    /// ��ʾ������Կ��ֵ
    /// </summary>
    public VirtualKey Key { get; }

    /// <summary>
    /// ��ʾ�����޸���һ����ѹ��������Կ
    /// </summary>
    public VirtualKeyModifiers Modifiers { get; }

    /// <summary>
    /// ��ʼ�� <see cref="ContextMenuItemShortcutKey"/> ����ʵ��
    /// </summary>
    /// <param name="key">ָ��������Կ��ֵ</param>
    /// <param name="modifiers">ָ�������޸���һ����ѹ��������Կ</param>
    public ContextMenuItemShortcutKey(VirtualKey key, VirtualKeyModifiers modifiers)
    {
        Key = key;
        Modifiers = modifiers;
    }
}

// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace GZSkinsX.SDK.ContextMenu;

/// <summary>
/// ��ʾ������ <see cref="IContextMenuUIContext"/> �Ļ���ʵ�֣���ͨ�����������������еĳ�Ա����
/// </summary>
/// <typeparam name="T1">ָ�� <see cref="UIObject"/> ������</typeparam>
/// <typeparam name="T2">ָ�� <see cref="Parameter"/> ������</typeparam>
public class ContextMenuUIContext<T1, T2> : ContextMenuUIContext, IContextMenuUIContext<T1, T2>
{
    /// <inheritdoc cref="IContextMenuUIContext{T1, T2}.UIObject"/>
    public new T1 UIObject => ((T1)base.UIObject)!;

    /// <inheritdoc cref="IContextMenuUIContext{T1, T2}.Parameter"/>
    public new T2 Parameter => ((T2)base.Parameter)!;

    /// <inheritdoc/>
    T1 IContextMenuUIContext<T1, T2>.UIObject => ((T1)base.UIObject)!;

    /// <inheritdoc/>
    T2 IContextMenuUIContext<T1, T2>.Parameter => ((T2)base.Parameter)!;

    /// <summary>
    /// ��ʼ�� <see cref="ContextMenuUIContext{T1, T2}"/> ����ʵ��
    /// </summary>
    /// <param name="uiObject">ָ����ǰ UI �������е� UI ����</param>
    /// <param name="parameter">ָ����ǰ UI �������еĲ���</param>
    public ContextMenuUIContext(T1 uiObject, T2 parameter)
        : base(uiObject!, parameter!) { }
}

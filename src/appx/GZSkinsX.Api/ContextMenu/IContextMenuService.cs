// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using Windows.UI.Xaml.Controls;

namespace GZSkinsX.Api.ContextMenu;

/// <summary>
/// ��ʾ�����Ĳ˵��Ļ������񣬲��ṩ���������Ĳ˵�������
/// </summary>
public interface IContextMenuService
{
    /// <summary>
    /// ͨ��ָ���� <paramref name="ownerGuidString"/> ����һ���µ� <see cref="MenuFlyout"/> ʵ��
    /// </summary>
    /// <param name="ownerGuidString">�Ӳ˵����������� <see cref="System.Guid"/> �ַ���ֵ</param>
    /// <param name="options">��ҪӦ�õ� UI �����Ĳ˵��ϵ���������</param>
    /// <param name="coerceValueCallback">Ŀ�� UI �����ĵĻص�ί��</param>
    /// <returns>�Ѵ����� <see cref="MenuFlyout"/> ����ʵ��</returns>
    MenuFlyout CreateContextFlyout(string ownerGuidString, ContextMenuOptions? options, CoerceContextMenuUIContextCallback? coerceValueCallback = null);
}

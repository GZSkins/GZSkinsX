// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;

using Windows.UI.Xaml.Controls;

namespace GZSkinsX.SDK.ContextMenu;

/// <summary>
/// ��ʾ�����Ĳ˵��Ļ������񣬲��ṩ���������Ĳ˵�������
/// </summary>
public interface IContextMenuService
{
    /// <summary>
    /// ͨ��ָ���� <see cref="Guid"/> �ַ���ֵ����һ���µ� <see cref="MenuFlyout"/> ʵ��
    /// </summary>
    /// <param name="ownerGuidString">�Ӳ˵����������� <see cref="System.Guid"/> �ַ���ֵ</param>
    /// <returns>�Ѵ����� <see cref="MenuFlyout"/> ����ʵ��</returns>
    MenuFlyout CreateContextMenu(string ownerGuidString);

    /// <summary>
    /// ͨ��ָ���� <see cref="Guid"/> �ַ���ֵ�� <see cref="ContextMenuOptions"/> �����Ĳ˵�ѡ�����ô���һ���µ� <see cref="MenuFlyout"/> ʵ��
    /// </summary>
    /// <param name="ownerGuidString">�Ӳ˵����������� <see cref="System.Guid"/> �ַ���ֵ</param>
    /// <param name="options">��ҪӦ�õ� UI �����Ĳ˵��ϵ���������ѡ��</param>
    /// <returns>�Ѵ����� <see cref="MenuFlyout"/> ����ʵ��</returns>
    MenuFlyout CreateContextMenu(string ownerGuidString, ContextMenuOptions options);

    /// <summary>
    /// ͨ��ָ���� <see cref="Guid"/> �ַ���ֵ�� <see cref="CoerceContextMenuUIContextCallback"/> UI �����ĵĻص�ί�д���һ���µ� <see cref="MenuFlyout"/> ʵ��
    /// </summary>
    /// <param name="ownerGuidString">�Ӳ˵����������� <see cref="System.Guid"/> �ַ���ֵ</param>
    /// <param name="coerceValueCallback">Ŀ�� UI �����ĵĻص�ί��</param>
    /// <returns>�Ѵ����� <see cref="MenuFlyout"/> ����ʵ��</returns>
    MenuFlyout CreateContextMenu(string ownerGuidString, CoerceContextMenuUIContextCallback coerceValueCallback);

    /// <summary>
    /// ͨ��ָ���� <see cref="Guid"/> �ַ���ֵ�� <see cref="ContextMenuOptions"/> �����Ĳ˵�ѡ�������Լ� <see cref="CoerceContextMenuUIContextCallback"/> UI �����ĵĻص�ί�д���һ���µ� <see cref="MenuFlyout"/> ʵ��
    /// </summary>
    /// <param name="ownerGuidString">�Ӳ˵����������� <see cref="System.Guid"/> �ַ���ֵ</param>
    /// <param name="options">��ҪӦ�õ� UI �����Ĳ˵��ϵ���������ѡ��</param>
    /// <param name="coerceValueCallback">Ŀ�� UI �����ĵĻص�ί��</param>
    /// <returns>�Ѵ����� <see cref="MenuFlyout"/> ����ʵ��</returns>
    MenuFlyout CreateContextMenu(string ownerGuidString, ContextMenuOptions options, CoerceContextMenuUIContextCallback coerceValueCallback);
}

// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.Composition;

namespace GZSkinsX.Api.ContextMenu;

/// <summary>
/// ��ʾ�����Ĳ˵����Ԫ������
/// </summary>
[MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class ContextMenuItemMetadataAttribute : Attribute
{
    /// <summary>
    /// ��ʾ�ò˵���� <see cref="System.Guid"/> �ַ���ֵ����ֵ����Ψһ��
    /// </summary>
    public string? Guid { get; set; }

    /// <summary>
    /// ��ʾ�ò˵����������ĸ��˵���� <see cref="System.Guid"/> �ַ���ֵ
    /// </summary>
    public string? OwnerGuid { get; set; }

    /// <summary>
    /// ��ʾ�ò˵������ڵķ��飬��ʽ�� "double,Guid" ��ʽ��ʾ
    /// </summary>
    public string? Group { get; set; }

    /// <summary>
    /// ��ʾ�ò˵���λ�ڷ����е�����˳��
    /// </summary>
    public double Order { get; set; }
}

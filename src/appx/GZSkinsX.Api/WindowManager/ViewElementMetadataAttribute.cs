// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.Composition;

namespace GZSkinsX.Api.WindowManager;

/// <summary>
/// ���ڵ�������ͼԪ�ص�Ԫ����
/// </summary>
[MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class ViewElementMetadataAttribute : Attribute
{
    /// <summary>
    /// ������ǰ��ͼԪ�صı�ʶ������ֵ����Ψһ��
    /// </summary>
    public required string Guid { get; set; }

    /// <summary>
    /// ���ڵ�����Ŀ��ҳ�����ͣ���ҳ�����ͱ���Ϊ <see cref="Page"/>���Ҳ���Ϊ��
    /// </summary>
    public required Type PageType { get; set; }
}

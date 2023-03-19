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
/// ���ڵ�����ҳ��Ԫ�ص�Ԫ����
/// </summary>
[MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class WindowFrameMetadataAttribute : Attribute
{
    /// <summary>
    /// ������ǰҳ��Ԫ�صı�ʶ������ֵ����Ψһ��
    /// </summary>
    public required string Guid { get; set; }

    /// <summary>
    /// ���ڵ�����Ŀ��ҳ�����ͣ���ҳ�����ͱ���Ϊ <see cref="Windows.UI.Xaml.Controls.Page"/>���Ҳ���Ϊ��
    /// </summary>
    public required Type PageType { get; set; }
}

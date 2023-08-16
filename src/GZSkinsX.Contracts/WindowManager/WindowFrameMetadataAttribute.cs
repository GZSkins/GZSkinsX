// Copyright 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "LICENSE.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.Composition;

namespace GZSkinsX.Contracts.WindowManager;

/// <summary>
/// 用于导出的页面元素的元数据
/// </summary>
[MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class WindowFrameMetadataAttribute : Attribute
{
    /// <summary>
    /// 声明当前页面元素的标识符，该值具有唯一性
    /// </summary>
    public required string Guid { get; set; }

    /// <summary>
    /// 用于导航的目标页面类型，该页面类型必须为 <see cref="Windows.UI.Xaml.Controls.Page"/>，且不能为空
    /// </summary>
    public required Type PageType { get; set; }
}

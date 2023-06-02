// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.Composition;

namespace GZSkinsX.SDK.WindowManager;

/// <summary>
/// ��������Ŀ������ <see cref="IWindowFrame"/> ���͵���
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class ExportWindowFrameAttribute : ExportAttribute
{
    /// <summary>
    /// ��ʼ�� <see cref="ExportWindowFrameAttribute"/> ����ʵ�������� <see cref="IWindowFrame"/> ���͵���
    /// </summary>
    public ExportWindowFrameAttribute()
        : base(typeof(IWindowFrame)) { }
}

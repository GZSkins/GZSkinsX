// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.Composition;

namespace GZSkinsX.Api.Shell;

/// <summary>
/// ��������Ŀ������ <see cref="IViewElement"/> ���͵���
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class ExportViewElementAttribute : ExportAttribute
{
    /// <summary>
    /// ��ʼ�� <see cref="ExportViewElementAttribute"/> ����ʵ�������� <see cref="IViewElement"/> ���͵���
    /// </summary>
    public ExportViewElementAttribute()
        : base(typeof(IViewElement)) { }
}

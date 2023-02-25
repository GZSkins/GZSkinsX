// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;

using GZSkinsX.Api.WindowManager;

namespace GZSkinsX.WindowManager;

/// <summary>
/// ���ڴ洢������ <see cref="IViewElement"/> �Լ�Ԫ���� <see cref="ViewElementMetadataAttribute"/> ��������
/// </summary>
internal sealed class ViewElementContext
{
    /// <summary>
    /// ��ǰ�������е������ض���
    /// </summary>
    private readonly Lazy<IViewElement, ViewElementMetadataAttribute> _lazy;

    /// <summary>
    /// ��ȡ��ǰ�����ض����ֵ
    /// </summary>
    public IViewElement Value => _lazy.Value;

    /// <summary>
    /// ��ȡ��ǰ�����ض����Ԫ����
    /// </summary>
    public ViewElementMetadataAttribute Metadata => _lazy.Metadata;

    /// <summary>
    /// ��ʼ�� <see cref="ViewElementContext"/> ����ʵ��
    /// </summary>
    public ViewElementContext(Lazy<IViewElement, ViewElementMetadataAttribute> lazy)
    {
        _lazy = lazy;
    }
}

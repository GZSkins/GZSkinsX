// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace GZSkinsX.Api.WindowManager;

/// <summary>
/// ���ڴ洢������ <see cref="IWindowFrame"/> �����Լ�����������
/// </summary>
public interface IWindowFrameContext
{
    /// <summary>
    /// ��ȡ��ǰ�����ĵ� <see cref="IWindowFrame"/> ����
    /// </summary>
    IWindowFrame Value { get; }

    /// <summary>
    /// ��ȡ��ǰ�����ĵ� <see cref="WindowFrameMetadataAttribute"/> Ԫ����
    /// </summary>
    WindowFrameMetadataAttribute Metadata { get; }
}

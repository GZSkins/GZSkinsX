// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace GZSkinsX.Api.WindowManager;

/// <summary>
/// �������¼���������������������ʱ��ʹ��
/// </summary>
public sealed class WindowFrameNavigateEventArgs : System.EventArgs
{
    /// <summary>
    /// ��ʾ��ǰ�¼��Ƿ��Ѿ���������Ϊ true ʱ������ǰ�¼��ѱ������Ҳ��ټ�������ִ��
    /// </summary>
    public bool Handled { get; set; }
}

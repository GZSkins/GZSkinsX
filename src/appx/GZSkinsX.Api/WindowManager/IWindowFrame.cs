// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace GZSkinsX.SDK.WindowManager;

/// <summary>
/// ��ʾλ��Ӧ�ó����������е�ҳ��Ԫ�أ�ͨ���������������ڽ���ҳ���л�
/// </summary>
public interface IWindowFrame
{
    /// <summary>
    /// ��ȡ��ǰ <see cref="IWindowFrame"/> �Ƿ���Խ��е���
    /// </summary>
    /// <param name="args">���뵼��ʱ���¼�����</param>
    /// <returns>������Ե�����Ŀ�� <see cref="IWindowFrame"/> �򷵻� true�����򷵻� false</returns>
    bool CanNavigateTo(WindowFrameNavigatingEvnetArgs args);
}

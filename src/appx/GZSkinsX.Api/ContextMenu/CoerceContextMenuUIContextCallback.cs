// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace GZSkinsX.Api.ContextMenu;

/// <summary>
/// ��ʾ�����ص��ķ������������¼��������Ĳ˵��е� UI ����������
/// </summary>
/// <param name="sender">�������Ĳ˵��� UI ����</param>
/// <param name="e">�������Ĳ˵���ʱ������Ĳ���</param>
/// <returns>�������¼����������������</returns>
public delegate IContextMenuUIContext CoerceContextMenuUIContextCallback(object sender, object e);

// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Collections.Generic;

namespace GZSkinsX.SDK.ContextMenu;

/// <summary>
/// �ṩ����ʵ�ֲ˵�����Զ����Ӽ������Ĳ˵��Ĳ˵����
/// </summary>
public interface IContextMenuItemProvider
{
    /// <summary>
    /// �����������Ӽ��������Ĳ˵����Ӳ˵����
    /// </summary>
    /// <returns>�����Ѵ������Ӳ˵����</returns>
    IEnumerable<CreatedContextMenuItem> CreateSubItems();
}

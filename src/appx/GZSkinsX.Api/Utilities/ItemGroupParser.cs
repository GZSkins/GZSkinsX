// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace GZSkinsX.Api.Utilities;

/// <summary>
/// �ṩ�������ض���ʽ��ʾ����ַ���ֵ������
/// </summary>
public static class ItemGroupParser
{
    /// <summary>
    /// ͨ���������ض���ʽ��ʾ����ַ���ֵ����ȡ������ص�Ԫ������Ϣ
    /// </summary>
    /// <param name="group">���ض���ʽ��ʾ����ַ���ֵ</param>
    /// <param name="name">ͨ��������õ��������������ʧ�����ʾΪ <see cref="string.Empty"/></param>
    /// <param name="order">ͨ��������õ��������˳���������ʧ�����ʾΪ <see cref="double.NaN"/></param>
    /// <returns>��������ɹ�����᷵�� <see cref="true"/>�����򽫷��� <see cref="false"/></returns>
    public static bool TryParseGroup(string group, out string name, out double order)
    {
        var indexOfSeparator = group.IndexOf(',');
        if (indexOfSeparator == -1 || !double.TryParse(group[..indexOfSeparator++], out order))
        {
            name = string.Empty;
            order = double.NaN;
            return false;
        }

        name = group[indexOfSeparator..];
        return true;
    }
}

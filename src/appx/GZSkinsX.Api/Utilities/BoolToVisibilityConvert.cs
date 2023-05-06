// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Windows.UI.Xaml;

namespace GZSkinsX.Api.Utilities;

/// <summary>
/// �ṩ�� <see cref="bool"/> �� <see cref="Visibility"/> �����໥ת��������
/// </summary>
public static class BoolToVisibilityConvert
{
    /// <summary>
    /// �� <see cref="Visibility"/> ���͵�ֵת��Ϊ <see cref="bool"/> ����
    /// </summary>
    /// <param name="value">��Ҫת����ֵ</param>
    /// <returns>��������ֵΪ <see cref="Visibility.Visible"/> �򷵻� true�����򷵻� false </returns>
    public static bool ToBoolean(Visibility value)
    {
        return value == Visibility.Visible;
    }

    /// <summary>
    /// �� <see cref="Visibility"/> ���͵�ֵת��Ϊ <see cref="bool"/> ����
    /// </summary>
    /// <param name="value">��Ҫת����ֵ</param>
    /// <returns>��������ֵΪ <see cref="Visibility.Collapsed"/> �򷵻� true�����򷵻� false </returns>
    public static bool ToBoolean2(Visibility value)
    {
        return value == Visibility.Collapsed;
    }

    /// <summary>
    /// �� <see cref="bool"/> ���͵�ֵת��Ϊ <see cref="Visibility"/> ����
    /// </summary>
    /// <param name="value">��Ҫת����ֵ</param>
    /// <returns>��������ֵΪ true �򷵻� <see cref="Visibility.Visible"/>�����򷵻� <see cref="Visibility.Collapsed"/> </returns>
    public static Visibility ToVisibility(bool value)
    {
        return value ? Visibility.Visible : Visibility.Collapsed;
    }

    /// <summary>
    /// �� <see cref="bool"/> ���͵�ֵת��Ϊ <see cref="Visibility"/> ����
    /// </summary>
    /// <param name="value">��Ҫת����ֵ</param>
    /// <returns>��������ֵΪ true �򷵻� <see cref="Visibility.Collapsed"/>�����򷵻� <see cref="Visibility.Visible"/> </returns>
    public static Visibility ToVisibility2(bool value)
    {
        return value ? Visibility.Collapsed : Visibility.Visible;
    }
}

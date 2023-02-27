// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Windows.UI;

namespace GZSkinsX.Api.Appx;

/// <summary>
/// ��ʾӦ�ó����еı�������ť
/// </summary>
public interface IAppxTitleBarButton
{
    /// <summary>
    /// ��ȡ�����ñ�����ǰ��ɫ���ڷǻ״̬ʱ����ɫ��
    /// </summary>
    /// <returns>�ǻʱ������ǰ������ɫ��(See <see cref="Color"/>)</returns>
    Color? InactiveForegroundColor { get; set; }

    /// <summary>
    /// ��ȡ�����ñ������ǻʱ�ı�����ɫ��
    /// </summary>
    /// <returns>�ǻʱ��������������ɫ��(See <see cref="Color"/>)</returns>
    Color? InactiveBackgroundColor { get; set; }

    /// <summary>
    /// ��ȡ�����ñ�����ǰ������ɫ��
    /// </summary>
    /// <returns>������ǰ������ɫ��(See <see cref="Color"/>)</returns>
    Color? ForegroundColor { get; set; }

    /// <summary>
    /// ��ȡ�����ð��±�������ťʱ��ǰ��ɫ��
    /// </summary>
    /// <returns>���±�������ťʱ��ǰ��ɫ��(See <see cref="Color"/>)</returns>
    Color? ButtonPressedForegroundColor { get; set; }

    /// <summary>
    /// ��ȡ�����ð��±�������ťʱ�ı�����ɫ��
    /// </summary>
    /// <returns>���±�������ťʱ�ı�����ɫ��(See <see cref="Color"/>)</returns>
    Color? ButtonPressedBackgroundColor { get; set; }

    /// <summary>
    /// ��ȡ�����ô��ڷǻ״̬ʱ��������ť��ǰ��ɫ��
    /// </summary>
    /// <returns>��������ť���ڷǻ״̬ʱ��ǰ��ɫ��(See <see cref="Color"/>)</returns>
    Color? ButtonInactiveForegroundColor { get; set; }

    /// <summary>
    /// ��ȡ�����ô��ڷǻ״̬ʱ��������ť�ı�����ɫ��
    /// </summary>
    /// <returns>��������ť���ڷǻ״̬ʱ�ı�����ɫ��(See <see cref="Color"/>)</returns>
    Color? ButtonInactiveBackgroundColor { get; set; }

    /// <summary>
    /// ��ȡ������ָ��λ�ڱ�������ť�Ϸ�ʱ��ǰ��ɫ��
    /// </summary>
    /// <returns>��ָ��λ�ڱ�������ť�Ϸ�ʱ���ð�ť��ǰ��ɫ��(See <see cref="Color"/>)</returns>
    Color? ButtonHoverForegroundColor { get; set; }

    /// <summary>
    /// ��ȡ������ָ��λ�ڱ�������ť�Ϸ�ʱ�ı�����ɫ��
    /// </summary>
    /// <returns>��ָ���ڱ�������ť��ʱ�����ı�����ɫ��(See <see cref="Color"/>)</returns>
    Color? ButtonHoverBackgroundColor { get; set; }

    /// <summary>
    /// ��ȡ�����ñ�������ť��ǰ��ɫ��
    /// </summary>
    /// <returns>��������ť��ǰ��ɫ��(See <see cref="Color"/>)</returns>
    Color? ButtonForegroundColor { get; set; }

    /// <summary>
    /// ��ȡ�����ñ�������ť�ı�����ɫ��
    /// </summary>
    /// <returns>��������ť�ı�����ɫ��(See <see cref="Color"/>)</returns>
    Color? ButtonBackgroundColor { get; set; }

    /// <summary>
    /// ��ȡ�����ñ�������������ɫ��
    /// </summary>
    /// <returns>��������������ɫ��(See <see cref="Color"/>)</returns>
    Color? BackgroundColor { get; set; }
}

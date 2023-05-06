// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.Collections.Generic;

using Windows.UI.Xaml.Controls;

namespace GZSkinsX.Api.Buffers;

/// <summary>
/// �ṩһ����Դ�أ�֧������������ <see cref="FontIcon"/> �� <typeparamref name="T"/> ���͵�ʵ��
/// </summary>
/// <typeparam name="T">��Դ���ж��������</typeparam>
public sealed class FontIconPool<T> where T : FontIcon, new()
{
    /// <summary>
    /// �����ص���Դ��ʵ�������������״η���ʱ��ô�����Դ��ʵ��
    /// </summary>
    private static readonly Lazy<FontIconPool<T>> s_lazy = new(() => new());

    /// <summary>
    /// ��ȡ����� <see cref="FontIconPool{T}"/> ��ʵ��
    /// </summary>
    public static FontIconPool<T> Shared => s_lazy.Value;

    /// <summary>
    /// ����ʵ�ֶ���Դ���л�����ֵ�
    /// </summary>
    private readonly Dictionary<string, WeakReference> _fontIconCache;

    /// <summary>
    /// ��ʼ�� <see cref="FontIconPool{T}"/> �ľ�̬��Ա
    /// </summary>
    private FontIconPool()
    {
        _fontIconCache = new Dictionary<string, WeakReference>();
    }

    /// <summary>
    /// �ӵ�ǰ��Դ���л�ȡ�ѻ���Ķ���򴴽�һ���µ���Դ����
    /// </summary>
    /// <param name="glyph">ͼ����ŵ��ַ�����</param>
    /// <returns>���ص�ǰ��Դ�����ѻ���Ķ������δ�ҵ���������ᴴ��һ���µĻ�������䷵��</returns>
    public T GetCacheOrCreate(string glyph)
    {
        T? result;

        if (_fontIconCache.TryGetValue(glyph, out var weakFontIcon))
        {
            result = weakFontIcon.Target as T;
            if (result is not null)
            {
                return result;
            }
        }

        result = new T() { Glyph = glyph };
        _fontIconCache[glyph] = new WeakReference(result);

        return result;
    }
}

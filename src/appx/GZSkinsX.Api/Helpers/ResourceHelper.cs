// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.Collections.Generic;

using GZSkinsX.SDK.Appx;
using GZSkinsX.SDK.MRT;

namespace GZSkinsX.SDK.Helpers;

/// <summary>
/// �ṩ���ٻ�ȡ���ػ���Դ�İ�����
/// </summary>
public static class ResourceHelper
{
    /// <summary>
    /// ���ڻ�ȡ���ػ���Դ���ڲ� <see cref="IMRTCoreMap"/> ��Ա����
    /// </summary>
    private static readonly IMRTCoreMap s_mrtCoreMap;

    /// <summary>
    /// ���ڻ��汾�ػ���Դ���ֵ�
    /// </summary>
    private static readonly Dictionary<string, WeakReference> s_resxCache;

    /// <summary>
    /// ��ʼ�� <see cref="ResourceHelper"/> �ľ�̬��Ա
    /// </summary>
    static ResourceHelper()
    {
        s_mrtCoreMap = AppxContext.MRTCoreService.MainResourceMap;
        s_resxCache = new Dictionary<string, WeakReference>();
    }

    /// <summary>
    /// ���ݴ������Դ���������Ի�ȡ���ػ���Դ
    /// </summary>
    /// <param name="resourceKey">��Ҫ��ȡ�ı��ػ�����Դ�ļ�</param>
    /// <returns>���ػ�ȡ���ı��ػ�����Դ</returns>
    public static string GetLocalized(string resourceKey)
    {
        string? result;
        if (s_resxCache.TryGetValue(resourceKey, out var weakResx))
        {
            result = weakResx.Target as string;
            if (result is not null)
            {
                return result;
            }
        }

        result = s_mrtCoreMap.GetString(resourceKey);
        s_resxCache[resourceKey] = new WeakReference(result);

        return result;
    }

    /// <summary>
    /// ���ݴ�������ض��ı�ʶ������Դ���������Ի�ȡ���ػ���Դ
    /// </summary>
    /// <param name="resourceKey">��Ҫ��ȡ�ı��ػ�����Դ�ļ�</param>
    /// <returns>�������� <paramref name="resourceKey"/> �����ض��ı�ʶ������ȡ���ػ�����Դ�����򽫻᷵��ԭ����</returns>
    public static string GetResxLocalizedOrDefault(string resourceKey)
    {
        if (resourceKey.StartsWith("resx:"))
        {
            string? result;
            var cacheKey = resourceKey[5..];

            if (s_resxCache.TryGetValue(cacheKey, out var weakResx))
            {
                result = weakResx.Target as string;
                if (result is not null)
                {
                    return result;
                }
            }

            result = s_mrtCoreMap.GetString(cacheKey);
            s_resxCache[resourceKey] = new WeakReference(result);

            return result;
        }
        else
        {
            return resourceKey;
        }
    }
}

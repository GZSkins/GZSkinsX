// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;

using GZSkinsX.Api.Appx;
using GZSkinsX.Api.Extension;
using GZSkinsX.Api.Logging;

using Windows.UI.Xaml;

namespace GZSkinsX.Extension;

/// <summary>
/// Ӧ�ó�����չ���񣬸�����غ�֪ͨ��ö�ٵ���չ
/// </summary>
[Shared, Export]
internal sealed class ExtensionService
{
    /// <summary>
    /// �����ö�ٵ�������չ�ļ���
    /// </summary>
    private readonly Lazy<IAdvanceExtension, AdvanceExtensionMetadataAttribute>[] _mefAdvanceExtensions;

    /// <summary>
    /// �����ö�ٵ�ͨ����չ�ļ���
    /// </summary>
    private readonly Lazy<IUniversalExtension, UniversalExtensionMetadataAttribute>[] _mefUniversalExtensions;

    /// <summary>
    /// ���ڼ�¼��־����־����
    /// </summary>
    private readonly ILoggingService _loggingService;

    /// <summary>
    /// ��ȡ����ͨ����չ��ʵ��
    /// </summary>
    public IEnumerable<IUniversalExtension> Extensions
    {
        get
        {
            foreach (var item in _mefUniversalExtensions)
            {
                yield return item.Value;
            }
        }
    }

    /// <summary>
    /// ��ʼ�� <see cref="ExtensionService"/> ����ʵ��
    /// </summary>
    [ImportingConstructor]
    public ExtensionService(
        [ImportMany] IEnumerable<Lazy<IAdvanceExtension, AdvanceExtensionMetadataAttribute>> mefAdvanceExtensions,
        [ImportMany] IEnumerable<Lazy<IUniversalExtension, UniversalExtensionMetadataAttribute>> mefUniversalExtensions)
    {
        _mefAdvanceExtensions = mefAdvanceExtensions.OrderBy(a => a.Metadata.Order).ToArray();
        _mefUniversalExtensions = mefUniversalExtensions.OrderBy(a => a.Metadata.Order).ToArray();

        _loggingService = AppxContext.LoggingService;
        _loggingService.LogAlways("ExtensionService: Initialized successfully.");
    }

    /// <summary>
    /// ��ȡ����ͨ����չ����������Դ�ֵ�ļ���
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ResourceDictionary> GetMergedResourceDictionaries()
    {
        foreach (var extension in _mefUniversalExtensions)
        {
            var value = extension.Value;
            foreach (var rsrc in value.MergedResourceDictionaries)
            {
                var asm = value.GetType().Assembly.GetName();
                var uri = new Uri($"ms-appx:///{asm.Name}/{rsrc}", UriKind.Absolute);
                yield return new ResourceDictionary { Source = uri };
            }
        }
    }

    /// <summary>
    /// ͨ��ɸѡָ���������͵�������չ���м���
    /// </summary>
    /// <param name="trigger">ָ���Ĵ�������</param>
    public void LoadAdvanceExtensions(AdvanceExtensionTrigger trigger)
    {
        foreach (var extension in _mefAdvanceExtensions)
        {
            if (extension.Metadata.Trigger == trigger)
            {
                _ = extension.Value;
            }
        }

        _loggingService.LogAlways($"ExtensionService: Load all AdvanceExtension of type '{trigger}'.");
    }

    /// <summary>
    /// �����е�ͨ����չ�����¼�֪ͨ
    /// </summary>
    /// <param name="eventType">��Ҫ֪ͨ���¼�����</param>
    public void NotifyUniversalExtensions(UniversalExtensionEvent eventType)
    {
        foreach (var extension in _mefUniversalExtensions)
        {
            extension.Value.OnEvent(eventType);
        }

        _loggingService.LogAlways($"ExtensionService: Notify event '{eventType}' for all universal extensions.");
    }
}

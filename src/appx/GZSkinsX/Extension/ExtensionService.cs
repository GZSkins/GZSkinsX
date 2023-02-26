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

using GZSkinsX.Api.Extension;

using Windows.UI.Xaml;

namespace GZSkinsX.Extension;

/// <summary>
/// Ӧ�ó�����չ���񣬸�����غ�֪ͨ�Ѽ��ص���չ
/// </summary>
[Shared]
[Export]
internal sealed class ExtensionService
{
    /// <summary>
    /// �Զ����ص������
    /// </summary>
    private readonly Lazy<IAutoLoaded, AutoLoadedMetadataAttribute>[] _mefAutoLoaded;

    /// <summary>
    /// ���������չ��
    /// </summary>
    private readonly Lazy<IExtension, ExtensionMetadataAttribute>[] _extensions;

    /// <summary>
    /// һ�����ڻ�ȡ������չʵ���ĵ�����
    /// </summary>
    public IEnumerable<IExtension> Extensions
    {
        get
        {
            foreach (var item in _extensions)
            {
                yield return item.Value;
            }
        }
    }

    /// <summary>
    /// ��ʼ�� <see cref="ExtensionService"/> ����ʵ��
    /// </summary>
    /// <param name="mefAutoLoaded">���Զ����ص��������</param>
    /// <param name="extensions">Ӧ�ó�����չ����</param>
    [ImportingConstructor]
    public ExtensionService(
        [ImportMany] IEnumerable<Lazy<IAutoLoaded, AutoLoadedMetadataAttribute>> mefAutoLoaded,
        [ImportMany] IEnumerable<Lazy<IExtension, ExtensionMetadataAttribute>> extensions)
    {
        _mefAutoLoaded = mefAutoLoaded.OrderBy(a => a.Metadata.Order).ToArray();
        _extensions = extensions.OrderBy(a => a.Metadata.Order).ToArray();
    }

    /// <summary>
    /// ��ȡ������չ����е� <see cref="ResourceDictionary"/> 
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ResourceDictionary> GetMergedResourceDictionaries()
    {
        foreach (var extension in _extensions)
        {
            var value = extension.Value;
            foreach (var rsrc in value.MergedResourceDictionaries)
            {
                var asm = value.GetType().Assembly.GetName();
                var uri = new Uri($"ms-appx://{asm.Name}/{rsrc}", UriKind.Absolute);
                yield return new ResourceDictionary { Source = uri };
            }
        }
    }

    /// <summary>
    /// ɸѡ������ָ�� '��������' �����ʵ��
    /// </summary>
    /// <param name="loadType">Ŀ�������������</param>
    public void LoadAutoLoaded(AutoLoadedType loadType)
    {
        foreach (var extension in _mefAutoLoaded)
        {
            if (extension.Metadata.LoadType == loadType)
            {
                _ = extension.Value;
            }
        }
    }

    /// <summary>
    /// ��Ӧ�ó�����չ��������¼�֪ͨ
    /// </summary>
    /// <param name="eventType">��Ҫ֪ͨ���¼�����</param>
    public void NotifyExtensions(ExtensionEvent eventType)
    {
        foreach (var extension in _extensions)
        {
            extension.Value.OnEvent(eventType);
        }
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(_mefAutoLoaded, _extensions);
    }
}

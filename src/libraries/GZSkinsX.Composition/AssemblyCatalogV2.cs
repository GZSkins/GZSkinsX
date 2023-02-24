// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.Collections.Generic;
using System.Reflection;

using GZSkinsX.Composition.Cache;

namespace GZSkinsX.Composition;

/// <summary>
/// һ�����������࣬����ö�� <see cref="Assembly"/> �б�
/// </summary>
public sealed class AssemblyCatalogV2 : IEquatable<AssemblyCatalogV2>
{
    /// <summary>
    /// ���ڴ�ų��򼯵ļ��ϡ�ʹ���ֵ䲢�� <see cref="Guid"/> ��Ϊ������
    /// </summary>
    private readonly Dictionary<Guid, Assembly> _guidToAsm;

    /// <summary>
    /// ���ڴ�ŵ�ǰ���Ŀ¼�Ļ��棬ֻ���ڱ���ȡ��ʱ��Ż�����
    /// </summary>
    private AssemblyCatalogV2Cache? _cache;

    /// <summary>
    /// ��ȡ��ǰ���Ŀ¼�Ļ���
    /// </summary>
    public AssemblyCatalogV2Cache Cache
    {
        get
        {
            if (_cache == null)
            {
                _cache = new AssemblyCatalogV2Cache();
                _cache.LoadFrom(this);
            }

            return _cache;
        }
    }

    /// <summary>
    /// ��ȡ��ö�ٵ� <see cref="Assembly"/>
    /// </summary>
    public IEnumerable<Assembly> Parts => _guidToAsm.Values;

    /// <summary>
    /// ��ʼ�� <see cref="AssemblyCatalogV2"/> ����ʵ��
    /// </summary>
    public AssemblyCatalogV2()
    {
        _guidToAsm = new Dictionary<Guid, Assembly>();
    }

    /// <summary>
    /// ��������ӵ����ϲ����ص�ǰ���� <see cref="AssemblyCatalogV2"/>
    /// </summary>
    /// <param name="assemblys">��Ҫ����ӵĳ���</param>
    /// <returns>��ǰ�������� <see cref="AssemblyCatalogV2"/></returns>
    public AssemblyCatalogV2 AddParts(IEnumerable<Assembly> assemblys)
    {
        foreach (var asm in assemblys)
        {
            _guidToAsm[asm.ManifestModule.ModuleVersionId] = asm;
        }

        return this;
    }

    /// <summary>
    /// ��������ӵ����ϲ����ص�ǰ���� <see cref="AssemblyCatalogV2"/>
    /// </summary>
    /// <param name="assemblys">��Ҫ����ӵĳ���</param>
    /// <returns>��ǰ�������� <see cref="AssemblyCatalogV2"/></returns>
    public AssemblyCatalogV2 AddParts(params Assembly[] assemblys)
    {
        foreach (var asm in assemblys)
        {
            _guidToAsm[asm.ManifestModule.ModuleVersionId] = asm;
        }

        return this;
    }

    /// <summary>
    /// �����������ĳ�����ӵ����ϲ����ص�ǰ���� <see cref="AssemblyCatalogV2"/>
    /// </summary>
    /// <param name="types">��Ҫ��ö�ٵ�����</param>
    /// <returns>��ǰ�������� <see cref="AssemblyCatalogV2"/></returns>
    public AssemblyCatalogV2 AddParts(IEnumerable<Type> types)
    {
        foreach (var type in types)
        {
            _guidToAsm[type.Assembly.ManifestModule.ModuleVersionId] = type.Assembly;
        }

        return this;
    }

    /// <summary>
    /// �����������ĳ�����ӵ����ϲ����ص�ǰ���� <see cref="AssemblyCatalogV2"/>
    /// </summary>
    /// <param name="types">��Ҫ��ö�ٵ�����</param>
    /// <returns>��ǰ�������� <see cref="AssemblyCatalogV2"/></returns>
    public AssemblyCatalogV2 AddParts(params Type[] types)
    {
        foreach (var type in types)
        {
            _guidToAsm[type.Assembly.ManifestModule.ModuleVersionId] = type.Assembly;
        }

        return this;
    }

    /// <inheritdoc/>
    public bool Equals(AssemblyCatalogV2? other)
    {
        if (other == null)
        {
            return false;
        }

        if (other._guidToAsm.Count != _guidToAsm.Count)
        {
            return false;
        }

        foreach (var guid in other._guidToAsm.Keys)
        {
            if (!_guidToAsm.ContainsKey(guid))
            {
                return false;
            }
        }

        return true;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return Equals(obj as AssemblyCatalogV2);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(
            _guidToAsm,
            _guidToAsm.Keys,
            _guidToAsm.Values);
    }
}

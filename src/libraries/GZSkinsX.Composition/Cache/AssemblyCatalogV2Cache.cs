// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.Collections.Generic;

using MessagePack;

namespace GZSkinsX.Composition.Cache;

/// <summary>
/// ���Ŀ¼���棬���ڻ������� <see cref="AssemblyCatalogV2"/> �еĳ��� <see cref="Guid"/> �б�
/// </summary>
[MessagePackObject]
public sealed class AssemblyCatalogV2Cache : IEquatable<AssemblyCatalogV2Cache>
{
    /// <summary>
    /// ʹ�� <see cref="HashSet{T}"/> �洢���򼯵� <see cref="Guid"/>���� <see cref="Guid"/> ����Ψһ��
    /// </summary>
    [Key(0)]
    private readonly HashSet<Guid> _guids;

    /// <summary>
    /// ��ʼ�� <see cref="AssemblyCatalogV2Cache"/> ����ʵ��
    /// </summary>
    public AssemblyCatalogV2Cache()
    {
        _guids = new HashSet<Guid>();
    }

    /// <summary>
    /// ��ָ���Ķ����м��ز����ɻ���
    /// </summary>
    /// <param name="assemblyCatalog">��Ҫ��������Ŀ¼</param>
    public void LoadFrom(AssemblyCatalogV2 assemblyCatalog)
    {
        _guids.Clear();

        foreach (var asm in assemblyCatalog.Parts)
        {
            _guids.Add(asm.ManifestModule.ModuleVersionId);
        }
    }

    /// <inheritdoc/>
    public bool Equals(AssemblyCatalogV2Cache? other)
    {
        if (other == null)
        {
            return false;
        }

        if (other._guids.Count != _guids.Count)
        {
            return false;
        }

        foreach (var guid in other._guids)
        {
            if (!_guids.Contains(guid))
            {
                return false;
            }
        }

        return true;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return Equals(obj as AssemblyCatalogV2Cache);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return _guids.GetHashCode();
    }
}

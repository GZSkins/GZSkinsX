// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.IO;
using System.Threading.Tasks;

using MessagePack;
using MessagePack.Resolvers;

using Microsoft.VisualStudio.Composition;

namespace GZSkinsX.Composition.Cache;

/// <summary>
/// �������д�������ɽ� <see cref="AssemblyCatalogV2Cache"/> �� <see cref="IExportProviderFactory"/> ��ʵ��д����������
/// </summary>
public sealed class CacheStreamWriter : IDisposable
{
    /// <summary>
    /// ��ǰ�� <see cref="AssemblyCatalogV2Cache"/> ������
    /// </summary>
    private readonly MemoryStream _assemblyCatalogCacheStream;

    /// <summary>
    /// ��ǰ�� <see cref="CompositionConfiguration"/> ������
    /// </summary>
    private readonly MemoryStream _compositionCacheStream;

    /// <summary>
    /// �����жϵ�ǰ���Ƿ���ù� Dispose �� DisposeAsync
    /// </summary>
    private bool _disposed;

    /// <summary>
    /// ��ʼ�� <see cref="CacheStreamWriter"/> ����ʵ��
    /// </summary>
    public CacheStreamWriter()
    {
        _assemblyCatalogCacheStream = new MemoryStream();
        _compositionCacheStream = new MemoryStream();
    }

    /// <summary>
    /// ������� <see cref="AssemblyCatalogV2Cache"/> ʵ��д�뵽����
    /// </summary>
    /// <param name="value">д��Ķ���</param>
    public async Task WriteAssemablyCatalogCacheAsync(AssemblyCatalogV2Cache value)
    {
        _assemblyCatalogCacheStream.SetLength(0);

        await MessagePackSerializer.SerializeAsync(
            _assemblyCatalogCacheStream, value,
            ContractlessStandardResolverAllowPrivate.Options);

        await _assemblyCatalogCacheStream.FlushAsync();
    }

    /// <summary>
    /// ������� <see cref="CompositionConfiguration"/> ʵ��д�뵽����
    /// </summary>
    /// <param name="value">д��Ķ���</param>
    public async Task WriteCompositionCacheAsync(CompositionConfiguration value)
    {
        _compositionCacheStream.SetLength(0);

        await new CachedComposition().SaveAsync(
            value, _compositionCacheStream);

        await _compositionCacheStream.FlushAsync();
    }

    /// <summary>
    /// ����ǰ�� <see cref="AssemblyCatalogV2Cache"/> �Լ� <see cref="CompositionConfiguration"/> �Ļ���һͬд����Ŀ�껺����
    /// </summary>
    /// <param name="cacheStream">Ŀ��д����</param>
    public async Task SaveAsync(Stream cacheStream)
    {
        using var bw = new BinaryWriter(cacheStream);

        // ����д��ڶ������ݶε�ƫ����
        // ��һ�����ݵ�ƫ����ʼ��Ϊ 4
        // Second Data Offset + First Data + Second Data
        bw.Write(4 + (int)_assemblyCatalogCacheStream.Length);

        bw.Write(_assemblyCatalogCacheStream.ToArray());
        bw.Write(_compositionCacheStream.ToArray());

        await cacheStream.FlushAsync();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (!_disposed)
        {
            _assemblyCatalogCacheStream.Dispose();
            _compositionCacheStream.Dispose();

            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}

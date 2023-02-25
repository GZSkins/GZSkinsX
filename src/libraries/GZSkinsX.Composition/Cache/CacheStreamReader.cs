// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.Buffers;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using MessagePack;
using MessagePack.Resolvers;

using Microsoft.VisualStudio.Composition;

namespace GZSkinsX.Composition.Cache;

/// <summary>
/// ��������ȡ������������ȡ <see cref="AssemblyCatalogV2Cache"/> �� <see cref="IExportProviderFactory"/> �Ļ���ʵ��
/// </summary>
public sealed class CacheStreamReader : IDisposable
{
    /// <summary>
    /// ��ǰ������
    /// </summary>
    private readonly Stream _cachedStream;

    /// <summary>
    /// �Ƿ����뿪������ʱ�رջ�������
    /// <para>��ֻ�ᱻ������ Dispose �� DisposeAsync ����</para>
    /// </summary>
    private readonly bool _leaveOpen;

    /// <summary>
    /// �����жϵ�ǰ���Ƿ���ù� Dispose �� DisposeAsync
    /// </summary>
    private bool _disposed;

    /// <summary>
    /// ��ʼ�� <see cref="CacheStreamReader"/> ����ʵ��
    /// </summary>
    /// <param name="cachedStream">����Ļ�����</param>
    public CacheStreamReader(Stream cachedStream)
        : this(cachedStream, true) { }

    /// <summary>
    /// ��ʼ�� <see cref="CacheStreamReader"/> ����ʵ��
    /// </summary>
    /// <param name="cachedStream">����Ļ�����</param>
    /// <param name="leaveOpen">�뿪������ʱ�Ƿ񱣳���Ϊ��״̬</param>
    public CacheStreamReader(Stream cachedStream, bool leaveOpen)
    {
        _cachedStream = cachedStream;
        _leaveOpen = leaveOpen;
    }

    /// <summary>
    /// �����ض����͵Ļ��沢���õ�ǰ����ƫ����
    /// </summary>
    /// <param name="isAssmblyCatalogCache">��Ҫ���ҵĻ������ͣ���Ϊ true ʱ��ʾ <see cref="AssemblyCatalogV2Cache"/>������Ϊ <see cref="CachedComposition"/></param>
    private void SeekCache(bool isAssmblyCatalogCache)
    {
        // ���� AssmblyCatalogCache ��Ĭ��ƫ����
        // ����� AssmblyCatalogCache ���������
        var offset = 4;
        if (!isAssmblyCatalogCache)
        {
            // ��ת���ļ�ͷ����ȡ�ڶ������ݵ�ƫ����
            _cachedStream.Seek(0, SeekOrigin.Begin);

            var buffer = ArrayPool<byte>.Shared.Rent(4);
            var count = _cachedStream.Read(buffer, 0, 4);
            Debug.Assert(count == 4);

            offset = MemoryMarshal.Read<int>(buffer);
            ArrayPool<byte>.Shared.Return(buffer, true);
        }

        // ��ת��Ŀ�껺�����ݵ���ʼλ��
        _cachedStream.Seek(offset, SeekOrigin.Begin);
    }

    /// <summary>
    /// �ڻ������ж�ȡ <see cref="AssemblyCatalogV2Cache"/> �Ļ���
    /// </summary>
    /// <returns>�ӻ������ж�ȡ���� <see cref="AssemblyCatalogV2Cache"/> ʵ��</returns>
    public async Task<AssemblyCatalogV2Cache> ReadAssemablyCatalogCacheAsync()
    {
        SeekCache(isAssmblyCatalogCache: true);
        return await MessagePackSerializer.DeserializeAsync<AssemblyCatalogV2Cache>(
            stream: _cachedStream, options: ContractlessStandardResolverAllowPrivate.Options);
    }

    /// <summary>
    /// �ڻ������ж�ȡ����� <see cref="CachedComposition"/> ���
    /// </summary>
    /// <param name="resolver">Ĭ�Ͻ�����</param>
    /// <returns>�ӻ������ж�ȡ���� <see cref="IExportProviderFactory"/> ʵ��</returns>
    public async Task<IExportProviderFactory> ReadCompositionCacheAsync(Resolver resolver)
    {
        SeekCache(isAssmblyCatalogCache: false);
        return await new CachedComposition().LoadExportProviderFactoryAsync(
            cacheStream: _cachedStream, resolver: resolver);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (!_disposed)
        {
            if (!_leaveOpen)
            {
                _cachedStream.Dispose();
            }

            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}

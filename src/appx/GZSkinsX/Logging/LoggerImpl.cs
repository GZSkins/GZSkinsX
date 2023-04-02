// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using GZSkinsX.DotNet.Diagnostics;

using Windows.Storage;

namespace GZSkinsX.Logging;

/// <summary>
/// Ӧ�ó����Ĭ����־����ʵ����
/// </summary>
internal sealed class LoggerImpl
{
    /// <summary>
    /// ���ڻ�ȡ��־��ʵ��������������
    /// </summary>
    private static readonly Lazy<LoggerImpl> s_lazy = new(() => new());

    /// <summary>
    /// ��ȡȫ�־�̬�����Ĭ����־����ʵ��
    /// </summary>
    public static LoggerImpl Shared => s_lazy.Value;

    /// <summary>
    /// ���ڱ�֤���߳���ͬ����¼���߳�������
    /// </summary>
    private readonly object _lockObj;

    /// <summary>
    /// ��־�ļ����������ֻ�б���ʼ����ſ�ʹ��
    /// </summary>
    private StreamWriter? _logWriter;

    /// <summary>
    /// ��ȡ���ж���־���Ƿ��ѽ��г�ʼ������
    /// </summary>
    private bool _isInitialize;

    /// <summary>
    /// ��ʼ�� <see cref="LoggerImpl"/> ����ʵ��
    /// </summary>
    private LoggerImpl()
    {
        _lockObj = new object();
    }

    /// <summary>
    /// ��ʼ����ǰ��־�����ļ������
    /// </summary>
    public async Task InitializeAsync()
    {
        if (_isInitialize)
        {
            return;
        }

        var _logsFolder = await ApplicationData.Current.LocalFolder
            .CreateFolderAsync("Logs", CreationCollisionOption.OpenIfExists);

        var _loggingFile = await _logsFolder.CreateFileAsync(
            string.Format("{0:yyyy-MM-ddTHH-mm-ss}_cor3.log", DateTime.Now),
                CreationCollisionOption.ReplaceExisting);

        var stream = await _loggingFile.OpenStreamForWriteAsync();
        _logWriter = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

        _isInitialize = true;
    }

    /// <summary>
    /// ����Ҫ��¼�������������־�ļ���
    /// </summary>
    /// <param name="message">Ҫ��¼������</param>
    public void Log(string message)
    {
        Debug2.Assert(_logWriter is not null);

        lock (_lockObj)
        {
            _logWriter.WriteLine(message);
        }
    }

    /// <summary>
    /// �رպ��ͷŵ�ǰ��־�����
    /// </summary>
    public void CloseOutputStream()
    {
        lock (_lockObj)
        {
            if (_logWriter is not null)
            {
                _logWriter.Close();
                _logWriter.Dispose();

                _logWriter = null;
                _isInitialize = false;
            }
        }
    }
}

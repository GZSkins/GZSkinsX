// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace GZSkinsX.SDK.Logging;

/// <summary>
/// ������־���񣬿�ͨ���˽���¼����ʵʱ���������
/// </summary>
public interface ILoggingService
{
    /// <summary>
    /// ���ó�����־��Ϣ��ʽ��д�����Ϣ
    /// </summary>
    /// <param name="message">Ҫд�����־��Ϣ�ַ���</param>
    void LogAlways(string message);

    /// <summary>
    /// ���õ�����־��Ϣ��ʽ��д�����Ϣ
    /// </summary>
    /// <param name="message">Ҫд�����־��Ϣ�ַ���</param>
    void LogDebug(string message);

    /// <summary>
    /// ���ô�����־��Ϣ��ʽ��д�����Ϣ
    /// </summary>
    /// <param name="message">Ҫд�����־��Ϣ�ַ���</param>
    void LogError(string message);

    /// <summary>
    /// ����ִ�гɹ�����־��Ϣ��ʽ��д�����Ϣ
    /// </summary>
    /// <param name="message">Ҫд�����־��Ϣ�ַ���</param>
    void LogOkay(string message);

    /// <summary>
    /// ���þ�����־��Ϣ��ʽ��д�����Ϣ
    /// </summary>
    /// <param name="message">Ҫд�����־��Ϣ�ַ���</param>
    void LogWarning(string message);

    /// <summary>
    /// ��ָ������־����������־��Ϣ��ʽ��д�����Ϣ
    /// </summary>
    /// <param name="level">���ڴ˼�����д����</param>
    /// <param name="message">Ҫд�����־��Ϣ�ַ���</param>
    void Log(LogLevel level, string message);
}

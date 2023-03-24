// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace GZSkinsX.Api.Logging;

/// <summary>
/// ������־��¼�����Լ���
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// ����Ӧ�ó���ĳ���������־�� ��Щ��־Ӧ���г��ڼ�ֵ��
    /// </summary>
    Always,
    /// <summary>
    /// �ڿ������������ڽ���ʽ�������־�� ��Щ��־Ӧ��Ҫ�����Ե������õ���Ϣ������û�г��ڼ�ֵ
    /// </summary>
    Debug,
    /// <summary>
    /// ��ǰִ��������϶�ֹͣʱͻ����ʾ����־�� ��Щ��־ָʾ��ǰ��еĹ��ϣ�������Ӧ�ó���Χ�ڵĹ���
    /// </summary>
    Error,
    /// <summary>
    /// ��ʾ�������ִ����ɵ���־����Щ��־���ڱ���ִ���������ɹ���״̬ (�� Error ���)�����Ҿ��г��ڼ�ֵ
    /// </summary>
    Okay,
    /// <summary>
    /// ͻ����ʾӦ�ó������е��쳣�������¼� (���ᵼ��Ӧ�ó���ִ��ֹͣ) ����־
    /// </summary>
    Warning
}

// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Collections.Generic;

using Windows.Storage;

namespace GZSkinsX.Api.MRT;

/// <summary>
/// �ṩ��Ӧ�ó�����Դӳ��ͱ��ػ���Դ�ķ���Ȩ��
/// </summary>
public interface IMRTCoreService
{
    /// <summary>
    /// ��ȡ�뵱ǰ�������е�Ӧ�ó�������������� <seealso cref="IMRTCoreMap"/>
    /// </summary>
    IMRTCoreMap MainResourceMap { get; }

    /// <summary>
    /// ����һ����������Դ���� (PRI) �ļ���������������ӵ�Ĭ����Դ������
    /// </summary>
    /// <param name="files">Ҫ��ӵİ���Դ���� (PRI) �ļ�</param>
    void LoadPriFiles(IEnumerable<IStorageFile> files);

    /// <summary>
    /// ж��һ����������Դ���� (PRI) �ļ�
    /// </summary>
    /// <param name="files">Ҫж�صİ���Դ���� (PRI) �ļ�</param>
    void UnloadPriFiles(IEnumerable<IStorageFile> files);
}

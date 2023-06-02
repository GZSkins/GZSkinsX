// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System.Composition;

using GZSkinsX.SDK.Settings;

using Windows.Storage;

namespace GZSkinsX.Settings;

/// <inheritdoc cref="ISettingsService"/>
[Shared, Export(typeof(ISettingsService))]
internal sealed class SettingsService : ISettingsService
{
    /// <summary>
    /// ���ڴ洢�������ݵ����ýڵ�
    /// </summary>
    private readonly SettingsSection _localSettingsSection;

    /// <summary>
    /// ���ڴ洢�������ݵ����ýڵ�
    /// </summary>
    private readonly SettingsSection _roamingSettingsSection;

    /// <summary>
    /// �߳��������Ա�֤�ڶ��߳�����Դ��ͬ������
    /// </summary>
    private readonly object _lockObj;

    /// <summary>
    /// ��ʼ�� <see cref="SettingsService"/> ����ʵ��
    /// </summary>
    public SettingsService()
    {
        _lockObj = new();

        var current = ApplicationData.Current;
        _localSettingsSection = new(current.LocalSettings, SettingsType.Local);
        _roamingSettingsSection = new(current.RoamingSettings, SettingsType.Roaming);
    }

    /// <inheritdoc/>
    public void DeleteSection(string name)
    {
        lock (_lockObj)
        {
            _localSettingsSection.GetOrCreateSection(name);
        }
    }

    /// <inheritdoc/>
    public void DeleteSection(string name, SettingsType type)
    {
        lock (_lockObj)
        {
            if (type == SettingsType.Roaming)
                _roamingSettingsSection.DeleteSection(name);
            else
                _localSettingsSection.DeleteSection(name);
        }
    }

    /// <inheritdoc/>
    public ISettingsSection GetOrCreateSection(string name)
    {
        ISettingsSection settingsSection;
        lock (_lockObj)
        {
            settingsSection = _localSettingsSection.GetOrCreateSection(name);
        }

        return settingsSection;
    }

    /// <inheritdoc/>
    public ISettingsSection GetOrCreateSection(string name, SettingsType type)
    {
        ISettingsSection settingsSection;
        lock (_lockObj)
        {
            settingsSection = type == SettingsType.Roaming
                ? _roamingSettingsSection.GetOrCreateSection(name)
                : _localSettingsSection.GetOrCreateSection(name);
        }

        return settingsSection;
    }
}

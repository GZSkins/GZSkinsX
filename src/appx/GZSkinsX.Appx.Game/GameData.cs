// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.IO;
using System.Linq;

using GZSkinsX.Api.Game;

namespace GZSkinsX.Appx.Game;

/// <inheritdoc cref="IGameData"/>
internal sealed class GameData : IGameData
{
    /// <summary>
    /// ��ʾ Game �ļ��еĵ����ƣ�������ʼ��Ϊһ���̶�ֵ
    /// </summary>
    private const string GAME_DIRECTORY_NAME = "Game";

    /// <summary>
    /// ��ʾ LOL ��Ϸ����ĵ��ļ����ƣ�������ʼ��Ϊһ���̶�ֵ
    /// </summary>
    private const string GAME_EXECUTE_NAME = "League of Legends.exe";

    /// <summary>
    /// ��ʾ LCU �ļ��е����ƣ�������ʼ��Ϊһ���̶�ֵ
    /// </summary>
    private const string LCU_DIRECTORY_NAME = "LeagueClient";

    /// <summary>
    /// ��ʾ LCU �ͻ��˳�����ļ����ƣ�������ʼ��Ϊһ���̶�ֵ
    /// </summary>
    private const string LCU_EXECUTE_NAME = "LeagueClient.exe";

    /// <inheritdoc/>
    public string GameDirectory { get; private set; }

    /// <inheritdoc/>
    public string GameExecutePath { get; private set; }

    /// <inheritdoc/>
    public string LCUDirectory { get; private set; }

    /// <inheritdoc/>
    public string LCUExecutePath { get; private set; }

    /// <summary>
    /// ��ʼ�� <see cref="GameData"/> ����ʵ��
    /// </summary>
    public GameData()
    {
        GameDirectory = string.Empty;
        GameExecutePath = string.Empty;
        LCUDirectory = string.Empty;
        LCUExecutePath = string.Empty;
    }

    /// <summary>
    /// ���ԴӴ���ָ������ϷĿ¼�Լ����������µ�ǰ��Ϸ���ݵĻ���·����Ϣ
    /// </summary>
    /// <param name="rootDirectory">��Ϸ�ĸ�Ŀ¼�ļ���</param>
    /// <param name="region">��Ϸ���ڵ����������</param>
    /// <returns>�ڳɹ���������ʱ���� true�����򷵻� false</returns>
    public bool TryUpdate(string rootDirectory, GameRegion region)
    {
        if (Directory.Exists(rootDirectory) && region != GameRegion.Unknown)
        {
            /// ����������ļ����ļ���·��
            var gameDirectory = Path.Combine(rootDirectory, GAME_DIRECTORY_NAME);
            var gameExecutePath = Path.Combine(gameDirectory, GAME_EXECUTE_NAME);

            var lcuDirectory = region == GameRegion.Riot
                ? rootDirectory
                : Path.Combine(rootDirectory, LCU_DIRECTORY_NAME);
            var lcuExecutePath = Path.Combine(lcuDirectory, LCU_EXECUTE_NAME);

            /// ������ DirectoryInfo ��ȡ�ļ�����Ϣ���ж��ļ��Ƿ����
            var gameDirectoryInfo = new DirectoryInfo(gameDirectory);
            var lcuDirectoryInfo = new DirectoryInfo(lcuDirectory);

            /// �����ж��ļ����Ƿ����
            if (gameDirectoryInfo.Exists is false || lcuDirectoryInfo.Exists is false)
            {
                return false;
            }

            /// File.Exists �����ﲻ���ã����޷���ȷ�жϣ����ֻ��ͨ����ȡ�ļ��б�����ж�
            if (gameDirectoryInfo.GetFiles(GAME_EXECUTE_NAME).Any(
                a => StringComparer.Ordinal.Equals(a.FullName, gameExecutePath))
                &&
                lcuDirectoryInfo.GetFiles(LCU_EXECUTE_NAME).Any(
                b => StringComparer.Ordinal.Equals(b.FullName, lcuExecutePath)))
            {
                GameDirectory = gameDirectory;
                GameExecutePath = gameExecutePath;
                LCUDirectory = lcuDirectory;
                LCUExecutePath = lcuExecutePath;

                return true;
            }
        }

        return false;
    }
}

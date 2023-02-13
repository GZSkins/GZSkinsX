﻿// Copyright 2022 - 2023 GZSkins, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License")
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace GZSkinsX.Contracts.Extension;

/// <summary>
/// 自动加载的扩展的触发类型
/// </summary>
public enum AutoLoadedType
{
    /// <summary>
    /// 在加载扩展之前
    /// </summary>
    BeforeExtensions,
    /// <summary>
    /// 在加载完扩展之后
    /// </summary>
    AfterExtensions,
    /// <summary>
    /// 在触发扩展的 <see cref="ExtensionEvent.Loaded"/> 事件之后
    /// </summary>
    AfterExtensionsLoaded,
    /// <summary>
    /// 在应用程序加载时
    /// </summary>
    AppLoaded
}

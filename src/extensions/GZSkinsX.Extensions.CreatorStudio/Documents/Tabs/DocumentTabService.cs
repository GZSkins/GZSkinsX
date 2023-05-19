﻿// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

#nullable enable

using System;
using System.Collections.Generic;
using System.Composition;
using System.Diagnostics;

using GZSkinsX.Api.CreatorStudio.Documents;
using GZSkinsX.Api.CreatorStudio.Documents.Tabs;

using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

using MUXC = Microsoft.UI.Xaml.Controls;

namespace GZSkinsX.Extensions.CreatorStudio.Documents.Tabs;

[Shared, Export(typeof(IDocumentTabService))]
internal sealed class DocumentTabService : IDocumentTabService
{
    private readonly IEnumerable<Lazy<IDocumentTabProvider, DocumentTabProviderMetadataAttribute>> _tabProviders;
    private readonly IDocumentService _documentService;

    private readonly Dictionary<Guid, DocumentTabProviderContext> _typedToProvider;

    private readonly MUXC.TabView _mainTabView;
    private readonly MenuFlyout _contextMenu;

    public object UIObject => _mainTabView;

    public IDocumentTab? ActiveTab
    {
        get
        {
            if (_mainTabView.SelectedItem is MUXC.TabViewItem tabViewItem &&
                tabViewItem.DataContext is DocumentTabContext context)
            {
                return context._tab;
            }

            return null;
        }
    }

    public IEnumerable<IDocumentTab> DocumentTabs
    {
        get
        {
            foreach (var item in _mainTabView.TabItems)
            {
                if (item is not MUXC.TabViewItem tabViewItem)
                    continue;

                if (tabViewItem.DataContext is not DocumentTabContext context)
                    continue;

                yield return context._tab;
            }
        }
    }

    public event EventHandler<ActiveDocumentTabChangedEventArgs>? ActiveTabChanged;

    public event TypedEventHandler<IDocumentTabService, DocumentTabCollectionChangedEventArgs>? CollectionChanged;

    [ImportingConstructor]
    public DocumentTabService(
        [ImportMany] IEnumerable<Lazy<IDocumentTabProvider, DocumentTabProviderMetadataAttribute>> tabProviders,
        IDocumentService documentService)
    {
        _mainTabView = new MUXC.TabView
        {
            IsAddTabButtonVisible = false,
            TabWidthMode = MUXC.TabViewWidthMode.Equal,
            VerticalAlignment = VerticalAlignment.Stretch,
            KeyboardAcceleratorPlacementMode = KeyboardAcceleratorPlacementMode.Hidden
        };

        _mainTabView.SelectionChanged += OnSelectionChanged;
        _mainTabView.TabCloseRequested += OnTabCloseRequested;

        _contextMenu = new MenuFlyout();

        _tabProviders = tabProviders;
        _documentService = documentService;
        _documentService.CollectionChanged += OnDocumentCollectionChanged;

        _typedToProvider = new Dictionary<Guid, DocumentTabProviderContext>();
        InitializeProviders();
    }

    private void InitializeProviders()
    {
        _typedToProvider.Clear();

        foreach (var item in _tabProviders)
        {
            var typedGuidString = item.Metadata.TypedGuid;
            var b = Guid.TryParse(typedGuidString, out var typedGuid);
            Debug.Assert(b, $"DocumentTabProvider: Couldn't parse TypedGuid property: '{typedGuidString}'");
            if (!b)
                continue;

            _typedToProvider[typedGuid] = new DocumentTabProviderContext(item);
        }
    }

    private void OnDocumentCollectionChanged(IDocumentService sender, DocumentCollectionChangedEventArgs args)
    {
        if (args.EventType == DocumentCollectionEventType.Add)
        {
            var addedItems = new List<IDocumentTab>();
            foreach (var doc in args.Documents)
            {
                if (_typedToProvider.TryGetValue(doc.Info.TypedGuid, out var providerContext))
                {
                    var createdTab = providerContext.Value.Create(doc);
                    var tabContext = new DocumentTabContext(doc, createdTab, _contextMenu);

                    _mainTabView.TabItems.Add(tabContext.UIObject);
                    tabContext.InternalOnAdded();
                    addedItems.Add(createdTab);
                }
            }

            _mainTabView.SelectedIndex = _mainTabView.TabItems.Count - 1;
            CollectionChanged?.Invoke(this, new DocumentTabCollectionChangedEventArgs(addedItems.ToArray(), null));
        }
        else
        {
            var removedItems = new List<IDocumentTab>();
            var tabItems = _mainTabView.TabItems;
            var count = tabItems.Count;

            foreach (var doc in args.Documents)
            {
                for (var i = 0; i < count; i++)
                {
                    if (tabItems[i] is not MUXC.TabViewItem item)
                        continue;

                    if (item.DataContext is not DocumentTabContext context)
                        continue;

                    if (context._doc.Key.Equals(doc.Key))
                    {
                        if (i == 0 && count > 1)
                        {
                            /// 如果此时需要被移除的元素正好是处于第 0 位，并且视图中还存在其它的选项卡，
                            /// 那么则需要把当前选择项调整至下一位元素，之后再进行移除的操作。
                            /// 如果不执行此段代码则会在 Remove 时引发 ArgumentException 异常。

                            _mainTabView.SelectedIndex = 1;
                        }

                        tabItems.RemoveAt(i);
                        context.InternalOnRemoved();
                        removedItems.Add(context._tab);

                        break;
                    }
                }
            }

            CollectionChanged?.Invoke(this, new DocumentTabCollectionChangedEventArgs(null, removedItems.ToArray()));
        }
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_mainTabView.SelectedItem is MUXC.TabViewItem tabViewItem &&
            tabViewItem.DataContext is DocumentTabContext context)
        {
            ActiveTabChanged?.Invoke(this, new ActiveDocumentTabChangedEventArgs(context._tab));
        }
        else
        {
            ActiveTabChanged?.Invoke(this, new ActiveDocumentTabChangedEventArgs(null));
        }
    }

    private void OnTabCloseRequested(MUXC.TabView sender, MUXC.TabViewTabCloseRequestedEventArgs args)
    {
        if (args.Tab.DataContext is DocumentTabContext context)
        {
            var args2 = new DocumentTabCloseRequestedEventArgs();
            context._tab.OnCloseRequested(args2);

            if (!args2.Handled)
            {
                _documentService.Remove(context._doc.Key);
            }
        }
    }

    public void Close(IDocumentTab tab)
    {
        if (tab is null)
        {
            throw new ArgumentNullException(nameof(tab));
        }

        var tabItems = _mainTabView.TabItems;
        var count = tabItems.Count;

        for (var i = 0; i < count; i++)
        {
            if (tabItems[i] is not MUXC.TabViewItem item)
                continue;

            if (item.DataContext is not DocumentTabContext context)
                continue;

            if (context._tab != tab)
                continue;

            _documentService.Remove(context._doc.Key);
            break;
        }
    }

    public void CloseActiveTab()
    {
        if (_mainTabView.SelectedItem is MUXC.TabViewItem item &&
            item.DataContext is DocumentTabContext context)
        {
            _documentService.Remove(context._doc.Key);
        }
    }

    public void CloseAllButActiveTab()
    {
        var activeTab = ActiveTab;
        if (activeTab is not null)
        {
            var removedKeys = new List<IDocumentKey>();
            var tabItems = _mainTabView.TabItems;
            var count = tabItems.Count;

            for (var i = 0; i < count; i++)
            {
                if (tabItems[i] is not MUXC.TabViewItem item)
                    continue;

                if (item.DataContext is not DocumentTabContext context)
                    continue;

                if (context._tab == activeTab)
                    continue;

                removedKeys.Add(context._doc.Key);
                break;
            }

            _documentService.Remove(removedKeys);
        }
    }

    public void CloseAllTabs()
    {
        _documentService.Clear();

        if (_mainTabView.TabItems.Count > 0)
        {
            var tabItems = _mainTabView.TabItems;
            var count = tabItems.Count;

            for (var i = 0; i < count; i++)
            {
                if (tabItems[i] is MUXC.TabViewItem item)
                {
                    if (item.DataContext is DocumentTabContext context)
                    {
                        /// ???
                        context.InternalOnRemoved();
                    }
                }

                tabItems.RemoveAt(i--);
            }
        }
    }

    public void SetActiveTab(int index)
    {
        if (index < 0 || index > _mainTabView.TabItems.Count)
        {
            return;
        }

        _mainTabView.SelectedIndex = index;
    }

    public void SetActiveTab(IDocumentTab tab)
    {
        if (tab is null)
        {
            throw new ArgumentNullException(nameof(tab));
        }

        var tabItems = _mainTabView.TabItems;
        for (var i = 0; i < tabItems.Count; i++)
        {
            if (tabItems[i] is not MUXC.TabViewItem item)
                continue;

            if (item.DataContext is not DocumentTabContext context)
                continue;

            if (context._tab != tab)
                continue;

            _mainTabView.SelectedIndex = i;
            break;
        }
    }
}

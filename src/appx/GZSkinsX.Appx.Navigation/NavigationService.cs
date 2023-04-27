// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
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
using System.Threading.Tasks;

using GZSkinsX.Api.MRT;
using GZSkinsX.Api.Navigation;
using GZSkinsX.Appx.Navigation.Controls;
using GZSkinsX.DotNet.Diagnostics;

using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

using MUXC = Microsoft.UI.Xaml.Controls;

namespace GZSkinsX.Appx.Navigation;

/// <inheritdoc cref="MUXC.NavigationView"/>
internal sealed class NavigationView2 : MUXC.NavigationView
{
    [DebuggerNonUserCode]
    public object GetTemplateChild2(string childName)
    {
        return GetTemplateChild(childName);
    }
}

/// <inheritdoc cref="INavigationService"/>
[Shared, Export(typeof(INavigationService))]
internal sealed class NavigationService : INavigationService
{
    /// <summary>
    /// ��������ѵ����� <see cref="INavigationGroup"/> ����ʵ��
    /// </summary>
    private readonly IEnumerable<Lazy<INavigationGroup, NavigationGroupMetadataAttribute>> _mefNavGroups;

    /// <summary>
    /// ��������ѵ����� <see cref="INavigationItem"/> ����ʵ��
    /// </summary>
    private readonly IEnumerable<Lazy<INavigationItem, NavigationItemMetadataAttribute>> _mefNavItems;

    /// <summary>
    /// ��ʾ���ڻ�ȡ���ػ���Դ�ķ���ʵ��
    /// </summary>
    private readonly IMRTCoreService _mrtCoreService;

    /// <summary>
    /// ���ڴ�����л���� <see cref="NavigationItemContext"/> ����ʵ��
    /// </summary>
    private readonly Dictionary<Guid, List<NavigationItemContext>> _guidToNavItems;

    /// <summary>
    /// ��������Ѵ����� <see cref="MUXC.NavigationViewItem"/> ����ʵ��
    /// </summary>
    internal readonly Dictionary<Guid, MUXC.NavigationViewItem> _createdNavItems;

    /// <summary>
    /// �洢���� <see cref="NavigationItemContext"/> ����ʵ������ʹ�� <see cref="Guid"/> ��Ϊ���Թ����ٷ���
    /// </summary>
    private readonly Dictionary<Guid, NavigationItemContext> _allNavItemCtx;

    /// <summary>
    /// ���ڴ��������ö�ٵ� <see cref="NavigationGroupContext"/> ����ʵ��
    /// </summary>
    private readonly List<NavigationGroupContext> _navGroups;

    /// <summary>
    /// �����л���������ڲ� <see cref="NavigationView2"/> ����ʵ��
    /// </summary>
    internal readonly NavigationView2 _navigationViewRoot;

    /// <summary>
    /// ���ڳ���ҳ����ڲ� <see cref="Frame"/> ����ʵ��
    /// </summary>
    internal readonly Frame _rootFrame;

    /// <inheritdoc/>
    public event NavigatedEventHandler? Navigated;

    /// <inheritdoc/>
    public bool CanGoBack => _rootFrame.CanGoBack;

    /// <inheritdoc/>
    public bool CanGoForward => _rootFrame.CanGoForward;

    /// <summary>
    /// ��ʼ�� <see cref="NavigationService"/> ����ʵ��
    /// </summary>
    [ImportingConstructor]
    public NavigationService(
        [ImportMany] IEnumerable<Lazy<INavigationGroup, NavigationGroupMetadataAttribute>> mefNavGroups,
        [ImportMany] IEnumerable<Lazy<INavigationItem, NavigationItemMetadataAttribute>> mefNavItems,
        IMRTCoreService mrtCoreService)
    {
        _mefNavGroups = mefNavGroups;
        _mefNavItems = mefNavItems;
        _mrtCoreService = mrtCoreService;

        _createdNavItems = new();
        _guidToNavItems = new();
        _allNavItemCtx = new();
        _navGroups = new();

        _navigationViewRoot = new();
        _rootFrame = new();

        InitializeNavGroups();
        InitializeNavItems();
        InitializeUIObject();
    }

    /// <summary>
    /// ��ʼ�����������л����е� <see cref="INavigationGroup"/> ����ʵ��
    /// </summary>
    private void InitializeNavGroups()
    {
        var hashes = new HashSet<Guid>();
        foreach (var item in _mefNavGroups)
        {
            var guidString = item.Metadata.Guid;
            var b = Guid.TryParse(guidString, out var guid);
            Debug.Assert(b, $"NavGroup: Couldn't parse Guid property: {guidString}");
            if (!b)
                continue;

            b = !hashes.Contains(guid);
            Debug.Assert(b, $"NavGroup: An group with the same GUID already exists");
            if (!b)
                continue;

            _navGroups.Add(new NavigationGroupContext(item));
        }

        _navGroups.Sort((a, b) => a.Metadata.Order.CompareTo(b.Metadata.Order));
    }

    /// <summary>
    /// ��ʼ�����������л����е� <see cref="INavigationItem"/> ����ʵ��
    /// </summary>
    private void InitializeNavItems()
    {
        foreach (var item in _mefNavItems)
        {
            var ownerGuidString = item.Metadata.OwnerGuid;
            var b = Guid.TryParse(ownerGuidString, out var ownerGuid);
            Debug.Assert(b, $"NavItem: Couldn't parse OwnerGuid property: {ownerGuidString}");
            if (!b)
                continue;

            var guidString = item.Metadata.Guid;
            b = Guid.TryParse(guidString, out var guid);
            Debug.Assert(b, $"NavItem: Couldn't parse Guid property: {guidString}");
            if (!b)
                continue;

            b = !string.IsNullOrEmpty(item.Metadata.Header);
            Debug.Assert(b, $"NavItem: Header is null or empty");
            if (!b)
                continue;

            if (!_guidToNavItems.TryGetValue(ownerGuid, out var list))
                _guidToNavItems.Add(ownerGuid, list = new List<NavigationItemContext>());
            list.Add(new NavigationItemContext(item));
        }

        foreach (var list in _guidToNavItems.Values)
        {
            var hashes = new HashSet<Guid>();
            var origin = new List<NavigationItemContext>(list);
            list.Clear();
            foreach (var group in origin)
            {
                var guid = new Guid(group.Metadata.Guid);
                if (hashes.Contains(guid))
                    continue;

                hashes.Add(guid);
                list.Add(group);

                _allNavItemCtx.Add(guid, group);
            }

            list.Sort((a, b) => a.Metadata.Order.CompareTo(b.Metadata.Order));
        }
    }

    /// <summary>
    /// ��ʼ���ڲ��� UI Ԫ�ض���
    /// </summary>
    private void InitializeUIObject()
    {
        _rootFrame.Navigated += OnNavigated;
        _navigationViewRoot.Content = _rootFrame;
        _navigationViewRoot.PaneDisplayMode = MUXC.NavigationViewPaneDisplayMode.Top;
        _navigationViewRoot.IsBackButtonVisible = MUXC.NavigationViewBackButtonVisible.Collapsed;
        _navigationViewRoot.IsTabStop = false;
        _navigationViewRoot.IsSettingsVisible = false;
        _navigationViewRoot.IsTitleBarAutoPaddingEnabled = false;
        _navigationViewRoot.PaneHeader = CreatePaneHeader();

        var navPaneCustomContent = new CustomizeNavPaneContent(this);
        _navigationViewRoot.PaneCustomContent = navPaneCustomContent;
        _navigationViewRoot.SelectionChanged += OnNavSelectionChanged;
        _navigationViewRoot.Resources.Add("TopNavigationViewTopNavGridMargin", new Thickness(4, 0, 188, 0));

        InitializeNavView(_navigationViewRoot);
    }

    /// <summary>
    /// ����Ӧ���� <see cref="MUXC.NavigationView.PaneHeader"/> �����ݣ�Ӧ�ñ��⣩
    /// </summary>
    private TextBlock CreatePaneHeader()
    {
        return new TextBlock
        {
            Margin = new(14, 0, 8, 0),
            VerticalAlignment = VerticalAlignment.Center,
            FontWeight = FontWeights.ExtraBold,
            IsHitTestVisible = false,
            Text = GetLocalizedOrDefault("resx:GZSkinsX.Appx.Navigation/Resources/MainAppx_Title")
        };
    }

    /// <summary>
    /// Ϊ������ͼ <see cref="MUXC.NavigationView"/> �������������
    /// </summary>
    /// <param name="navigationView">��Ҫ���г�ʼ���� <see cref="MUXC.NavigationView"/> ����ʵ��</param>
    private void InitializeNavView(MUXC.NavigationView navigationView)
    {
        var needSeparator = false;
        foreach (var group in _navGroups)
        {
            var container = navigationView.MenuItems;
            var guid = new Guid(group.Metadata.Guid);
            if (_guidToNavItems.TryGetValue(guid, out var navItems))
            {
                if (navItems.Count == 0)
                    continue;

                if (needSeparator)
                    container.Add(new MUXC.NavigationViewItemSeparator());
                else
                    needSeparator = true;

                foreach (var item in navItems)
                    container.Add(CreateNavItemUIObject(item));
            }
        }
    }

    /// <summary>
    /// �� <see cref="MUXC.NavigationView"/> ��ѡ�񵼺���ʱ��������������ѡ�������е�������
    /// </summary>
    private void OnNavSelectionChanged(MUXC.NavigationView sender, MUXC.NavigationViewSelectionChangedEventArgs args)
    {
        var navItem = args.SelectedItem as MUXC.NavigationViewItem;
        if (navItem is null or { SelectsOnInvoked: false })
        {
            return;
        }

        var guid = (Guid)navItem.Tag;
        if (_allNavItemCtx.TryGetValue(guid, out var context))
        {
            _rootFrame.Tag = guid;
            Debug2.Assert(context.Metadata.PageType is not null);
            _rootFrame.Navigate(context.Metadata.PageType);
        }
    }

    /// <summary>
    /// �ڵ�����Ŀ��ҳ��ʱ��������ͬ��������ͼ�е�ѡ����
    /// <para>
    /// ����ͨ����̨ Api ���е������������� UI ��ѡ��ʱ����Ҫ�ֶ�ͬ��������ͼ�е�ѡ���
    /// </para>
    /// </summary>
    private async void OnNavigated(object sender, NavigationEventArgs e)
    {
        var guid = (Guid)_rootFrame.Tag;
        if (_allNavItemCtx.TryGetValue(guid, out var ctx) is false ||
            _createdNavItems.TryGetValue(guid, out var item) is false)
        {
            return;
        }

        await ctx.Value.OnNavigatedToAsync(e);
        _navigationViewRoot.SelectedItem = item;

        Navigated?.Invoke(sender, e);
    }

    /// <summary>
    /// ͨ������ <see cref="NavigationItemContext"/> �����Ķ��󲢴��� <see cref="MUXC.NavigationViewItem"/> ����ʵ��
    /// </summary>
    /// <param name="context">��Ҫ������ <see cref="NavigationItemContext"/> �����Ķ���</param>
    /// <returns>�Ѵ����� <see cref="MUXC.NavigationViewItem"/> ����ʵ��</returns>
    private MUXC.NavigationViewItem CreateNavItemUIObject(NavigationItemContext context)
    {
        var guid = new Guid(context.Metadata.Guid);
        var navItem = new MUXC.NavigationViewItem
        {
            Tag = guid,
            Icon = context.Value.Icon,
            Content = GetLocalizedOrDefault(context.Metadata.Header),
            SelectsOnInvoked = context.Metadata.PageType is not null
        };

        AutomationProperties.SetName(navItem, navItem.Content as string);

        if (_guidToNavItems.TryGetValue(guid, out var navItems))
        {
            foreach (var item in navItems)
            {
                var subItem = CreateNavItemUIObject(item);
                navItem.MenuItems.Add(subItem);
            }
        }

        _createdNavItems.Add(guid, navItem);
        return navItem;
    }

    /// <summary>
    /// ���ݴ�������ض��ı�ʶ������Դ���������Ի�ȡ���ػ���Դ
    /// </summary>
    /// <param name="resourceKey">��Ҫ��ȡ�ı��ػ�����Դ�ļ�</param>
    /// <returns>�������� <paramref name="resourceKey"/> �����ض��ı�ʶ������ȡ���ػ�����Դ�����򽫻᷵��ԭ����</returns>
    internal string GetLocalizedOrDefault(string resourceKey)
    {
        if (resourceKey.StartsWith("resx:"))
        {
            return _mrtCoreService.MainResourceMap.GetString(resourceKey[5..]);
        }
        else
        {
            return resourceKey;
        }
    }

    /// <summary>
    /// ��ȡ�뵱ǰ������ͼ�е�ѡ������������ <see cref="NavigationItemContext"/> �����Ķ���
    /// </summary>
    /// <returns>����ҵ��������� <see cref="NavigationItemContext"/> �����Ķ�����᷵�ظ�ʵ�������򷵻ؿ�</returns>
    private NavigationItemContext? GetCurrentNavItemCtx()
    {
        if (_navigationViewRoot.SelectedItem is MUXC.NavigationViewItem selectedItem
            && _allNavItemCtx.TryGetValue((Guid)selectedItem.Tag, out var ctx))
        {
            return ctx;
        }

        return null;
    }

    /// <inheritdoc/>
    public bool GoBack()
    {
        if (CanGoBack)
        {
            var beforeNavItemCtx = GetCurrentNavItemCtx();
            _rootFrame.GoBack();
            beforeNavItemCtx?.Value.OnNavigatedFromAsync();
            return true;
        }

        return false;
    }

    /// <inheritdoc/>
    public bool GoForward()
    {
        if (CanGoForward)
        {
            var beforeNavItemCtx = GetCurrentNavItemCtx();
            _rootFrame.GoForward();
            beforeNavItemCtx?.Value.OnNavigatedFromAsync();
            return true;
        }

        return false;
    }

    /// <inheritdoc/>
    public async void NavigateTo(string guidString)
    {
        if (Guid.TryParse(guidString, out var guid))
        {
            await NavigateCoreAsync(guid, null, null);
        }
    }

    /// <inheritdoc/>
    public async void NavigateTo(string guidString, object parameter)
    {
        if (Guid.TryParse(guidString, out var guid))
        {
            await NavigateCoreAsync(guid, parameter, null);
        }
    }

    /// <inheritdoc/>
    public async void NavigateTo(string guidString, object parameter, NavigationTransitionInfo infoOverride)
    {
        if (Guid.TryParse(guidString, out var guid))
        {
            await NavigateCoreAsync(guid, parameter, infoOverride);
        }
    }

    /// <inheritdoc/>
    public async void NavigateTo(Guid navItemGuid)
    {
        await NavigateCoreAsync(navItemGuid, null, null);
    }

    /// <inheritdoc/>
    public async void NavigateTo(Guid navItemGuid, object parameter)
    {
        await NavigateCoreAsync(navItemGuid, parameter, null);
    }

    /// <inheritdoc/>
    public async void NavigateTo(Guid navItemGuid, object parameter, NavigationTransitionInfo infoOverride)
    {
        await NavigateCoreAsync(navItemGuid, parameter, infoOverride);
    }

    /// <summary>
    /// ���ĵ�����������������ĵ�������ʵ�֡��󲿷ֵ�����ص� Api ��ʹ�ô˺�������ҳ�浼��
    /// </summary>
    internal async Task NavigateCoreAsync(Guid guid, object? parameter, NavigationTransitionInfo? infoOverride)
    {
        if (_allNavItemCtx.TryGetValue(guid, out var context) is false)
        {
            return;
        }

        var beforeNavItemCtx = GetCurrentNavItemCtx();
        infoOverride ??= new DrillInNavigationTransitionInfo();

        _rootFrame.Tag = guid;
        Debug2.Assert(context.Metadata.PageType is not null);
        if (_rootFrame.Navigate(context.Metadata.PageType, parameter, infoOverride))
        {
            if (beforeNavItemCtx is not null)
            {
                await beforeNavItemCtx.Value.OnNavigatedFromAsync();
            }
        }
    }
}

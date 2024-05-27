using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Navigation;
using ST_Lc2.ViewModels;

namespace ST_Lc2.Views;

public partial class MainWindow : Window
{
    private ViewModelBase _current;
    private Stack<ToggleButton> stack = new Stack<ToggleButton>();

    public MainWindow()
    {
        InitializeComponent();
    }

    public void MinimizeWindow(object? sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
    
    public void MaximizeWindow(object? sender, RoutedEventArgs e)
    {
        if (this.WindowState == WindowState.Maximized)
        {
            this.WindowState = WindowState.Normal;
        }
        else
        {
            this.WindowState = WindowState.Maximized;
        }
    }
    public void CloseWindow(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void NavView_OnItemInvoked(object? sender, NavigationViewItemInvokedEventArgs e)
    {
        if (e.InvokedItemContainer is NavigationViewItem item)
        {
            if (item.Tag is String page)
            {
                switch(page)
                {
                   case "Home":
                       Frame2.Navigate((typeof(HomeView)));
                       break;
                   case  "Tools":
                       Frame2.Navigate((typeof(ToolsView)));
                       break;
                }           
            }
            
        }
    }

    private void Frame2_OnNavigated(object sender, NavigationEventArgs e)
    {

    }
}
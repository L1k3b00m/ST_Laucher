using System.Collections.Generic;
using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;
using ST_Lc2.ViewModels;

namespace ST_Lc2.Views;

public partial class MainWindow : Window
{
    private Stack<ToggleButton> stack = new Stack<ToggleButton>();
    private NativeMenuItem? nativeMenu;

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

    private void TreeView_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        
        throw new System.NotImplementedException();
    }

    private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.InvokedItem != null)
        {
            
        }
    }
    
}
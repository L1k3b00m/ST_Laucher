using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.ComponentModel;
using ST_Lc2.ViewModels;

namespace ST_Lc2.Views;

public partial class MainWindow : Window
{


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
    
}
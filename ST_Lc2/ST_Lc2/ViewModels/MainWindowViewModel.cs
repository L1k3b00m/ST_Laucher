using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using FluentAvalonia.UI.Controls;
using ReactiveUI;
using ST_Lc2.navigatiom;
using ST_Lc2.ViewModels;
using ST_Lc2.Views;

namespace ST_Lc2.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public NavigationItem NavigationItem => new NavigationItem();
    private ViewModelBase _current;

    public ObservableCollection<NavigationItem> Nav_list;
    public MainWindowViewModel()
    {
        
        Nav_list = new ObservableCollection<NavigationItem>
        {
            new NavigationItem()
            {
                Tag = "Home",
                content = "Home",
                icon = new Image{Source = new Bitmap("../../../Assets/home_rgl.png")},
                icon_family = "Segoe Fluent Icons"
            },
            new NavigationItem()
            {
                Tag = "Tools",
                content = "Tools",
                icon = new Image{Source = new Bitmap("../../../Assets/home_rgl.png")},
                icon_family = "Segoe Fluent Icons"
            }
        };

    }

    public ObservableCollection<NavigationItem> NavigationItems
    {
        get => Nav_list;
        set => this.RaiseAndSetIfChanged(ref Nav_list, value);
    }
    public ViewModelBase Current   
    {
        get => _current;
        set => this.RaiseAndSetIfChanged(ref _current, value);
    }

    public void GotoHome()
    {
        Current = new HomeViewModel();
    }

    public void GotoTools()
    {
        Current = new ToolsViewModel();
    }

    public string gett => "dsadasdasdsad";
    

    // public ICollection<toggleButtonItem> ToggleButtonItems
    // {
    //     get => ToggleButtons;
    //     set => this.RaiseAndSetIfChanged(ref ToggleButtons, value);
    // }


}
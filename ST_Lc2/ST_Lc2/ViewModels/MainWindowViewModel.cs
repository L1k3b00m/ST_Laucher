using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using CommunityToolkit.Mvvm.Input;
using ReactiveUI;
using ST_Lc2.navigatiom;
using ST_Lc2.ViewModels;
using ST_Lc2.Views;

namespace ST_Lc2.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _current = new HomeViewModel();
    
    public MainWindowViewModel()
    {
        togglebuttonlist = new ObservableCollection<toggleButtonItem>
        {
            new toggleButtonItem
            {
                //home
                commod = new RelayCommand(GotoHome),
                icon = "\xE80F"
            },
            new toggleButtonItem
            {
                //tools
                commod = new RelayCommand(GotoTools),
                icon = "\xE90F"
            }
        };
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
    
    public ObservableCollection<toggleButtonItem> togglebuttonlist { get; set; }
    // public ICollection<toggleButtonItem> ToggleButtonItems
    // {
    //     get => ToggleButtons;
    //     set => this.RaiseAndSetIfChanged(ref ToggleButtons, value);
    // }
}
using ReactiveUI;
using ST_Lc2.ViewModels;
using ST_Lc2.Views;

namespace ST_Lc2.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _current;
    
    // public MainWindowViewModel()
    // {
    //     Current = new HomeViewModel();
    // }
    public ViewModelBase Current   
    {
        get => _current;
        set => this.RaiseAndSetIfChanged(ref _current, value);
    }

    public void GotoHome()
    {
        Current = new HomeViewModel();
    }
}
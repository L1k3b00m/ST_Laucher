using System.Net.Mime;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using ReactiveUI;
namespace ST_Lc2.ViewModels;

public class ToolsViewModel : ViewModelBase
{
    public Image Image_view
    {
        get => img;
        set => this.RaiseAndSetIfChanged(ref img, value);
    }

    private Image img;

    public ToolsViewModel()
    {
        Image_view = new HomeViewModel().Image_view;
    }
    

}
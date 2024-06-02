using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ST_Lc2.ViewModels;

namespace ST_Lc2.Views;

public partial class ToolsView : UserControl
{
    public ToolsView()
    {
        InitializeComponent();
        DataContext = new ToolsViewModel();

    }
}
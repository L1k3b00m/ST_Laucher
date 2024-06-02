using System.Windows.Input;
using Avalonia.Controls;
using FluentAvalonia.UI.Controls;

namespace ST_Lc2.navigatiom;

public class NavigationItem
{
    public string Tag { get; set; }

    public  string content { get; set; }
    
    public Image icon { get; set; }
    
    public string icon_family { get; set; }
}
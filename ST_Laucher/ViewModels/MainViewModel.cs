using System.Linq;
using KMCCC.Launcher;
using KMCCC;

namespace ST_Laucher.ViewModels;

public class MainViewModel : ViewModelBase
{   
    public string Greeting => "Welcome to Avalonia!";

    public Version[] Versions => LauncherCore.Create().GetVersions().ToArray();

}

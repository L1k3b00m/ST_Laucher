using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using KMCCC;
using ST_Laucher.laucherCore.tools;
using Microsoft.Win32;
using System.Collections;
using System.Linq;
using KMCCC.Authentication;
using KMCCC.Launcher;
using SquareMinecraftLauncher.Core;
using System.Runtime.ConstrainedExecution;
using System.Collections.Generic;
using DynamicData;

namespace ST_Laucher.Views;

public partial class MainView : UserControl
{

    public static IEnumerable<string> java_ver;
    public static Version[] versions;
    KMCCC.Launcher.LauncherCore core = KMCCC.Launcher.LauncherCore.Create();
    public MainView()
    {
        InitializeComponent();
        //获取java版本
        java_ver = SystemTools.FindJava();
        //获取版本
        versions = core.GetVersions().ToArray();
        //导入前端
        versionsList.ItemsSource = versions;
        javaList.ItemsSource = java_ver;

        if(versions.Length == 0) { Debug.WriteLine("没有版本"); }
        foreach (var version in versions)
        {
            Debug.WriteLine(version.ToString());
        }
        foreach (var version in java_ver)
        {
            Debug.WriteLine(version.ToString());
        }
    }

    public void start(object source, RoutedEventArgs args)
    {
        Debug.WriteLine(javaList.SelectedItem);
        core.JavaPath = (string)javaList.SelectedItem;
        var ver = (KMCCC.Launcher.Version)versionsList.SelectedItem;
        
        var result = core.Launch(new KMCCC.Launcher.LaunchOptions
        {
            Version = ver,
            MaxMemory = 2048,
            Authenticator = new OfflineAuthenticator("YOUR_FATHER"),
            Mode = LaunchMode.MCLauncher,
            Size = new WindowSize{Height = 768, Width = 1280}
        });
        Debug.WriteLine(result.ToString);
    }
    
}

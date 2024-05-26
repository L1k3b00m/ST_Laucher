using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using ST_Lc2.ViewModels;
using ST_Lc2.Views;

namespace ST_Lc2;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? param)
    {
        if (param is MainWindowViewModel) return new MainWindow();
        if (param is HomeViewModel) return new HomeView();
        if (param is ToolsViewModel) return new ToolsView();
        throw new NotImplementedException();
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}
﻿using System;
 using System.Diagnostics;
 using ReactiveUI;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using ST_Lc2.Views;

namespace ST_Lc2.ViewModels;

public class HomeViewModel : ViewModelBase
{
    private string? file_path;

    private async Task OpenFile(CancellationToken token)
    {

        //判断是否存在窗口
        if(Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
           desktop.MainWindow?.StorageProvider is not {} provider)
            throw new NullReferenceException("Missing StorageProvider instance.");
        var file = await provider.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "选择一个图片",
            AllowMultiple  = false,
            FileTypeFilter = new []
            {
                new FilePickerFileType("图片文件")
                {
                    Patterns = new []{
                        "*.jpg",
                        "*.png",
                        "*.jpeg",
                        "*.gif",
                        "*.bmp",
                        "*.tif",
                        "*.tiff",
                        "*.ico",
                        "*.cur",
                        "*.svg",
                        "*.webp",
                        "*.avif",
                        "*.apng",
                        "*.jxl",
                    }
                }
            }
        });
        
    }
    // private async Task<IStorageFile?> DoOpenFilePickerAsync()
    // {
    //     // For learning purposes, we opted to directly get the reference
    //     // for StorageProvider APIs here inside the ViewModel. 
    //
    //     // For your real-world apps, you should follow the MVVM principles
    //     // by making service classes and locating them with DI/IoC.
    //
    //     // See IoCFileOps project for an example of how to accomplish this.
    //     if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
    //         desktop.MainWindow?.StorageProvider is not { } provider)
    //         throw new NullReferenceException("Missing StorageProvider instance.");
    //
    //     var files = await provider.OpenFilePickerAsync(new FilePickerOpenOptions()
    //     { 
    //         Title = "Open Text File",
    //         AllowMultiple = false
    //     });
    //
    //     return files?.Count >= 1 ? files[0] : null;
    // }
    private string _a = "1312313122312312312312";
    
    public string GTER =>  "1312313122312312312312";
    public string Gett
    {
        get => _a;
        set => this.RaiseAndSetIfChanged(ref _a, value);
    }
    public void ButtonAction()
    {
        Gett = "31231231222312312";
        Debug.WriteLine("321312312312312");
    }
}
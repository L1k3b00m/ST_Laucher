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
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ST_Lc2.Views;
using Avalonia.Media.Imaging;

namespace ST_Lc2.ViewModels;

public class HomeViewModel : ViewModelBase
{
    private string? file_path;

    private Image image;

    private string result;

    public string predictResult
    {
        get => result;
        set => this.RaiseAndSetIfChanged(ref result, value);
    }
    public Image Image_view
    {
        get => image;
        set => this.RaiseAndSetIfChanged(ref image ,value);
    }

    private async Task OpenFile()
    {
        try
        {
            var file = await DoOpenFilePickerAsync();
            if(file is null) return;
            if ((await file.GetBasicPropertiesAsync()).Size <= 10024 * 10024 * 1)
            {
                var filePath = file.TryGetLocalPath();
                file_path = filePath;
                Image_view = new Image { Source = new Bitmap(filePath) };
            }
            else
            {
                throw new Exception("超过10MB");
            }
        }
        catch (Exception e)
        {
            throw new Exception("读取失败");
        }
    }
    private async Task<IStorageFile?> DoOpenFilePickerAsync()
    {
        // For learning purposes, we opted to directly get the reference
        // for StorageProvider APIs here inside the ViewModel. 
    
        // For your real-world apps, you should follow the MVVM principles
        // by making service classes and locating them with DI/IoC.
    
        // See IoCFileOps project for an example of how to accomplish this.
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
            desktop.MainWindow?.StorageProvider is not { } provider)
            throw new NullReferenceException("Missing StorageProvider instance.");
    
        var files = await provider.OpenFilePickerAsync(new FilePickerOpenOptions()
        { 
            Title = "Open Text File",
            AllowMultiple = false
        });
    
        return files?.Count >= 1 ? files[0] : null;
    }
    
    //机器学习实现
    public async void buttonAction()
    {
        await OpenFile();
        if (file_path is not null)
        {
            var Image = File.ReadAllBytes(file_path);
            MLModel1.ModelInput predictData = new MLModel1.ModelInput()
            {
                ImageSource = Image,
            };

            //Load model and predict output
            var result = MLModel1.Predict(predictData);

            predictResult = result.PredictedLabel;
        }
        else
        {
            var box =MessageBoxManager.GetMessageBoxStandard("错误!", "你没有选择文件", ButtonEnum.YesNo,Icon.Error);

            var result = await box.ShowAsync();
        }
        
    }
}
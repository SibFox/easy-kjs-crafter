using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.DeclarationsRedactor;
using EasyKJSCrafter.Scenes.UIs.MainMenu;
using EasyKJSCrafter;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public partial class LoadingScreen : Control
{
    // private ProgressBar _progressBar;
    // private LinkedList<Action> TasksToPerform = [];
    
    // // Обычный int, который мы будем безопасно менять через Interlocked
    // private int _completedCount = 0;
    // private bool _isLoading = false;

    // public override void _Ready()
    // {
    //     InitTasks();

    //     _progressBar = GetNode<ProgressBar>("VBoxContainer/MarginContainer/LoadingProgress");
    //     _progressBar.MaxValue = TasksToPerform.Count;
    //     _progressBar.Value = 0;

    //     // WorkerThreadPool.AddGroupTask(Callable.From(TasksToPerform.ElementAt), TasksToPerform.Count);
    //     _isLoading = true;
    //     for (int i = 0; i < _progressBar.MaxValue-1; i++)
    //     {
    //         WorkerThreadPool.AddTask(Callable.From(() => TasksToPerform.ElementAt(i)()));
    //     }
    // }

    // void InitTasks()
    // {
    //     TasksToPerform.AddLast(LoadMainMenuUI);
    //     TasksToPerform.AddLast(LoadDeclarationsRedactorUI);
    //     TasksToPerform.AddLast(LoadItemsDeclarations);
    //     TasksToPerform.AddLast(LoadTagsDeclarations);
    //     TasksToPerform.AddLast(LoadFluidsDeclarations);
    // }

    // public override void _Process(double delta)
    // {
    //     if (!_isLoading) return;

    //     // Безопасно считываем текущее значение для UI
    //     // Для чтения одиночного int на 32-битных/64-битных системах операция чтения атомарна сама по себе
    //     int currentValue = Volatile.Read(ref _completedCount);

    //     _progressBar.Value = currentValue;

    //     if (currentValue >= _progressBar.MaxValue)
    //     {
    //         _isLoading = false;
    //         GD.Print("Загрузка ресурсов завершена");

    //         Global.Main.UIHandler.ChangeTo(Global.LoadedUIScenes.MainMenu);
    //     }
    // }

// #region Методы загрузки

//     void LoadMainMenuUI()
//     {
//         MainMenu load = ResourceLoader.Load<PackedScene>("res://Scenes/UIs/MainMenu/MainMenu.tscn").Instantiate<MainMenu>();
//         Global.LoadedUIScenes.MainMenu = load;
        
//         Interlocked.Increment(ref _completedCount);
//     }

//     void LoadDeclarationsRedactorUI()
//     {
//         DeclarationsRedactor load = ResourceLoader.Load<PackedScene>("res://Scenes/UIs/DeclarationsRedactor/DeclarationsRedactor.tscn").Instantiate<DeclarationsRedactor>();
//         Global.LoadedUIScenes.DeclarationsRedactor = load;

//         Interlocked.Increment(ref _completedCount);
//     }

//     void LoadItemsDeclarations()
//     {
//         ItemCollection load = ResourceLoader.Load<ItemCollection>("res://Resources/Items.tres");
//         Global.LoadedDeclarations.Items = load;

//         Interlocked.Increment(ref _completedCount);
//     }

//     void LoadTagsDeclarations()
//     {
//         ItemCollection load = ResourceLoader.Load<ItemCollection>("res://Resources/Tags.tres");
//         Global.LoadedDeclarations.Tags = load;

//         Interlocked.Increment(ref _completedCount);
//     }

//     void LoadFluidsDeclarations()
//     {
//         ItemCollection load = ResourceLoader.Load<ItemCollection>("res://Resources/Fluids.tres");
//         Global.LoadedDeclarations.Fluids = load;

//         Interlocked.Increment(ref _completedCount);
//     }

// #endregion
}

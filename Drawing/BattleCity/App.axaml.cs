using Avalonia;
using BattleCity.Model;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BattleCity.references;
using System.Diagnostics;
using System.Reactive.Concurrency;

namespace BattleCity;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime lifetime)
        {
            var mainWindow = new MainWindow();

            var field = new GameField();
            var game = new Game(field);
            GameReferences.FieldRef = field;
            GameReferences.Stopwatch = new Stopwatch();
            GameReferences.Stopwatch.Start();
            game.Start();
            mainWindow.DataContext = field;

            lifetime.MainWindow = mainWindow;
        }
    }
}

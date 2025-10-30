using DailyWpfApp.Navigation;
using DailyWpfApp.ViewModels;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DailyWpfApp.Views;

namespace DailyWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly IHost _host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) => {
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<WebServerPage>();
            services.AddSingleton<WebServerPageViewModel>();
            services.AddSingleton<HomePage>();
            services.AddSingleton<HomePageViewModel>();
            services.AddSingleton<SettingsPage>();
            services.AddSingleton<SettingsPageViewModel>();
        }).Build();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _host.Start();
            //指定启动窗口
            this.MainWindow = _host.Services.GetRequiredService<MainWindow>();
            this.MainWindow.Show();
        }

    }

}

﻿using DailyWpfApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DailyWpfApp.Views
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPageViewModel VM { get; }
        public SettingsPage(SettingsPageViewModel viewModel)
        {
            VM = viewModel;
            DataContext = this;
            InitializeComponent();
        }


        private void Services_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://go.microsoft.com/fwlink/?LinkId=822631") { UseShellExecute = true });
        }

        private void Privacy_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://go.microsoft.com/fwlink/?LinkId=521839") { UseShellExecute = true });
        }

        private void Open_Issues(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/microsoft/WPF-Samples/issues/new") { UseShellExecute = true });
        }

        private void Open_ToolkitInformation(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.nuget.org/packages/CommunityToolkit.Mvvm/") { UseShellExecute = true });
        }

        private void Open_DIInformation(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/") { UseShellExecute = true });
        }

        private void Open_HostingInformation(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.nuget.org/packages/Microsoft.Extensions.Hosting") { UseShellExecute = true });
        }

        private void ThemeMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Change_ThemeMode.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedValue = selectedItem.Content.ToString()!;

                // WPF0001: 'System.Windows.Application.ThemeMode' is for evaluation purposes only and is subject to change or removal in future updates.
                // To suppress this diagnostic, add a pragma directive as shown below.
#pragma warning disable WPF0001
                switch (selectedValue)
                {
                    case "Light":
                        Application.Current.ThemeMode = ThemeMode.Light;
                        break;
                    case "Dark":
                        Application.Current.ThemeMode = ThemeMode.Dark;
                        break;
                    case "Use system setting":
                        Application.Current.ThemeMode = ThemeMode.System;
                        break;
                    default:
                        break;
                }
#pragma warning restore WPF0001
            }
        }
    }
}

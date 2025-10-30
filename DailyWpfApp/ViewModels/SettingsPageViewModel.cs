using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyWpfApp.ViewModels
{
    public partial class SettingsPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _pageTitle = "Settings 1234";

        [ObservableProperty]
        private string _pageDescription = "Settings 1234567890";
    }
}

using DailyWpfApp.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyWpfApp.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _NavigationPanelIsOpen;
        public MainWindowViewModel()
        {

        }
        [RelayCommand]
        public void HumbergerMenuClicked()
        {
            NavigationPanelIsOpen = !NavigationPanelIsOpen;
        }

    }
}

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
        [ObservableProperty]
        private bool _CanNavigateback;
        private readonly INavigationService _navigationService;

        public MainWindowViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        [RelayCommand]
        public void HumbergerMenuClicked()
        {
            NavigationPanelIsOpen = !NavigationPanelIsOpen;
        }

        [RelayCommand]
        public void Back()
        {
            _navigationService.NavigateBack();
        }

        [RelayCommand]
        public void Forward()
        {
            _navigationService.NavigateForward();
        }
        internal void UpdateCanNavigateBack()
        {
            CanNavigateback = _navigationService.IsBackHistoryNonEmpty();
        }
    }
}

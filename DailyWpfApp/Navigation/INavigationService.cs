using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyWpfApp.Navigation
{
    public interface INavigationService
    {
        void Navigate(Type type, bool adjustFocus = true);

        void NavigateTo(Type type);

        void SetFrame(Frame frame);

        void NavigateBack();

        void NavigateForward();

        bool IsBackHistoryNonEmpty();

        event EventHandler<NavigatingEventArgs> Navigating;
    }
}

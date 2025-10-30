using DailyWpfApp.Helpers;
using DailyWpfApp.Navigation;
using DailyWpfApp.ViewModels;
using DailyWpfApp.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace DailyWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //这里定义ViewModel属性，在XAML中绑定时，绑定VM的所有属性，都要加上ViewModel.前缀
        public MainWindowViewModel VM { get; }
        private readonly INavigationService _navigationService;

        public MainWindow(MainWindowViewModel viewModel, IServiceProvider serviceProvider, INavigationService navigationService)
        {
            VM = viewModel;
            _navigationService = navigationService;

            DataContext = this;
            InitializeComponent();
            //订阅导航事件（当向前，向后，和导航至特点页面的事后触发）
            //_navigationService.Navigating += OnNavigating;
            //设置导航框架(该代码必须写在InitializeComponent方法后面，否则找不到对应的控件)
            _navigationService.SetFrame(this.RootContentFrame);
            //默认导航到首页
            _navigationService.Navigate(typeof(HomePage), false);

            //这里设置窗口样式，让窗口有圆角和阴影
            WindowChrome.SetWindowChrome(
                this,
                new WindowChrome
                {
                    CaptionHeight = 48, // 标题栏可拖动区域的高度
                    CornerRadius = new CornerRadius(12),
                    GlassFrameThickness = new Thickness(-1),
                    ResizeBorderThickness = ResizeMode == ResizeMode.NoResize ? default : new Thickness(4),
                    UseAeroCaptionButtons = true,
                    NonClientFrameEdges = SystemParameters.HighContrast ? NonClientFrameEdges.None :
                        NonClientFrameEdges.Right | NonClientFrameEdges.Bottom | NonClientFrameEdges.Left
                }
            );
        }

        //导航完成后，更新ViewModel中的CanNavigateBack属性
        private void RootContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            VM.UpdateCanNavigateBack();

            Type type = e.Content!.GetType()!;
            //在导航前，更新导航列表的选择
            foreach (ListBoxItem item in NavigationListBox.Items)
            {
                string? tag = (string?)item.Tag;
                if (tag != null)
                {
                    Type pageType = Type.GetType(tag)!;
                    if (pageType == type)
                    {
                        NavigationListBox.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        //导航列表选择变化时，导航到对应的页面
        private void NavigationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem? selectedItem = (ListBoxItem?)NavigationListBox.SelectedItem;
            if (selectedItem != null)
            {
                string? tag = (string?)selectedItem.Tag;
                if (tag != null)
                {
                    //把文字转换为Type类型，然后导航到对应的页面。后面的叹号是告诉编译器，这个值不为null。
                    Type pageType = Type.GetType(tag)!;
                    _navigationService.Navigate(pageType);
                }
            }
        }
        //private void OnNavigating(object? sender, NavigatingEventArgs e)
        //{
            //Type type= e.PageType!;
            ////在导航前，更新导航列表的选择
            //foreach (ListBoxItem item in NavigationListBox.Items)
            //{
            //    string? tag = (string?)item.Tag;
            //    if (tag != null)
            //    {
            //        Type pageType = Type.GetType(tag)!;
            //        if (pageType == type)
            //        {
            //            NavigationListBox.SelectedItem = item;
            //            break;
            //        }
            //    }
            //}
        //}


        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.Navigate(typeof(SettingsPage));
        }
    }
}
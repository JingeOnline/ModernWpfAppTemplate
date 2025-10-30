# DailyWpfApp

参考项目：https://github.com/microsoft/WPF-Samples/tree/main/Sample%20Applications/WPFGallery ，简化了该项目中复杂的树形结构导航和页面模板部分。

特点
1. 汉堡菜单+页面导航
2. WinUI3样式的窗口标题栏
3. 支持WinUI3的主题切换

       //在SettingPage.xaml.cs文件中，实现主题切换。该功能还在实验阶段，后续.net版本该功能是否保留不确定。
       #pragma warning disable WPF0001
       Application.Current.ThemeMode = ThemeMode.Light;
       #pragma warning restore WPF0001
   
5. 通过在App.xaml中添加如下代码，实现把WPF默认控件转换为新的WinUI3样式
   
       <Application.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                    <ResourceDictionary Source="Styles/MainWindowStyle.xaml" />
                    <ResourceDictionary Source="pack://application:,,,/PresentationFramework.Fluent;component/Themes/Fluent.xaml" />
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
        </Application.Resources>

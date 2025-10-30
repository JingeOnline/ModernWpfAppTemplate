namespace DailyWpfApp.Navigation;

/// <summary>
/// Service for navigating between pages.
/// </summary>
public class NavigationService : INavigationService
{
    private Frame _frame;
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void SetFrame(Frame frame)
    {
        _frame = frame;
    }
    //ʹ����������ȡ��Ӧ���͵�ҳ��ʵ����Ȼ�󵼺�����ҳ��
    public void Navigate(Type type)
    {
        if (type != null)
        {
            var page = _serviceProvider.GetRequiredService(type);
            _frame.Navigate(page);
        }
    }

}

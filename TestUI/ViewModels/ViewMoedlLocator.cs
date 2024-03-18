using Microsoft.Extensions.DependencyInjection;

namespace TestUI.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}

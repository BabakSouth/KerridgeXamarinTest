using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using KerridgeTask.Services;

namespace KerridgeTask
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            Services = serviceProvider;
            MainPage = new AppShell();
        }
    }
}

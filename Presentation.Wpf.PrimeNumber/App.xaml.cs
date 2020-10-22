using Microsoft.Extensions.DependencyInjection;
using Presentation.Wpf.PrimeNumber.Actions;
using Presentation.Wpf.PrimeNumber.ValidationRules;
using System;
using System.Windows;

namespace Presentation.Wpf.PrimeNumber
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceColleciton = new ServiceCollection();

            ConfigureService(serviceColleciton);

            ServiceProvider = serviceColleciton.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();

            mainWindow.Show();
        }

        private void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<INumberValidationRule, NumberValidationRule>();

            services.AddTransient<IPrimeNumberAction, PrimeNumberAction>();

            services.AddTransient(typeof(MainWindow));
        }
    }
}

using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using Cursovaya.Infrastructure;
using Cursovaya.Model;
using Cursovaya.Model.DataStructs;
using Cursovaya.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Cursovaya
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DIContainer.BindAsSingle<MainWindowVM>();
            DIContainer.BindAsSingle<HelpWindowVM>();
            DIContainer.BindAsSingle<HelpWindowService>();
            DIContainer.BindAsSingle<GlobalArray<int>>();
            DIContainer.BindAsSingle<FindMethodCreator<int>>();
            DIContainer.Build();
        }
    }

}

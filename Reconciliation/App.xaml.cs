using EvoCafe.DAL;
using EvoCafe.DAL.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Reconciliation
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
        }

        private void ConfigureContainer()
        {
            _container = new StandardKernel();
            _container.Bind<IUnitOfWork>().To<UnitOfWork>().InTransientScope().WithConstructorArgument("dbContext", new BDContext());
        }
    }
}

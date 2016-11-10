﻿namespace Example.WpfApplication
{
    using System;
    using System.Windows;

    using Example.WpfApplication.Infrastructure;
    using Example.WpfApplication.Models;
    using Example.WpfApplication.Views;

    using Ninject;

    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public sealed partial class App : IDisposable
    {
        private readonly StandardKernel kernel = new StandardKernel();

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            kernel.Dispose();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            RegisterComponents();

            MainWindow = kernel.Get<MainWindow>();
            kernel.Get<IWindowManager>().Load();
        }

        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:スコープを失う前にオブジェクトを破棄", Justification = "Factory")]
        private void RegisterComponents()
        {
            // Infrastructure
            kernel.Bind<IDependencyResolver>().To<NinjectDependencyResolver>().InSingletonScope();

            // Application model
            kernel.Bind<Counter>().ToConstant(new Counter(5));

            // View & ViewModel
            kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();

            kernel.Bind<OperationViewModel>().ToSelf();
            kernel.Bind<OperationWindow>().ToSelf().InSingletonScope();

            kernel.Bind<ResultViewModel>().ToSelf();
            kernel.Bind<ResultWindow>().ToSelf().InSingletonScope();

            kernel.Bind<MainViewModel>().ToSelf();
            kernel.Bind<MainWindow>().ToSelf().InSingletonScope();
        }
    }
}

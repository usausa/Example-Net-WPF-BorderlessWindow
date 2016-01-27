namespace Example.WpfApplication.Views
{
    using System;
    using System.Globalization;
    using System.Windows;

    using Example.WpfApplication.Infrastructure;

    using Smart.ComponentModel;

    /// <summary>
    ///
    /// </summary>
    public interface IWindowManager
    {
        /// <summary>
        ///
        /// </summary>
        bool OperationVisible { get; set; }

        /// <summary>
        ///
        /// </summary>
        bool ResultVisible { get; set; }

        /// <summary>
        ///
        /// </summary>
        void Load();

        /// <summary>
        ///
        /// </summary>
        void Save();
    }

    /// <summary>
    ///
    /// </summary>
    public class WindowManager : NotificationObject, IWindowManager
    {
        private readonly IDependencyResolver resolver;

        private OperationWindow operationWindow;

        private ResultWindow resultWindow;

        /// <summary>
        ///
        /// </summary>
        public bool OperationVisible
        {
            get { return operationWindow != null && operationWindow.IsVisible; }
            set
            {
                if (operationWindow == null)
                {
                    operationWindow = resolver.Resolve<OperationWindow>();
                    operationWindow.Owner = resolver.Resolve<MainWindow>();
                    SetPoint(Properties.Settings.Default.OperationWindowPosition, (x, y) => { operationWindow.Left = x; operationWindow.Top = y; });
                }

                if (value)
                {
                    operationWindow.Show();
                }
                else
                {
                    operationWindow.Hide();
                }

                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///
        /// </summary>
        public bool ResultVisible
        {
            get { return resultWindow != null && resultWindow.IsVisible; }
            set
            {
                if (resultWindow == null)
                {
                    resultWindow = resolver.Resolve<ResultWindow>();
                    resultWindow.Owner = resolver.Resolve<MainWindow>();
                    SetPoint(Properties.Settings.Default.ResultWindowPosition, (x, y) => { resultWindow.Left = x; resultWindow.Top = y; });
                }

                if (value)
                {
                    resultWindow.Show();
                }
                else
                {
                    resultWindow.Hide();
                }

                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="resolver"></param>
        public WindowManager(IDependencyResolver resolver)
        {
            this.resolver = resolver;
        }

        /// <summary>
        ///
        /// </summary>
        public void Load()
        {
            var settings = Properties.Settings.Default;

            var mainWindow = resolver.Resolve<MainWindow>();
            SetPoint(settings.MainWindowPosition, (x, y) => { mainWindow.Left = x; mainWindow.Top = y; });
            SetPoint(settings.MainWindowSize, (x, y) => { mainWindow.Width = x; mainWindow.Height = y; });
            if (settings.MainWindowMaximized)
            {
                mainWindow.WindowState = WindowState.Maximized;
            }

            mainWindow.Show();

            if (settings.OperationWindowVisible)
            {
                OperationVisible = true;
            }

            if (settings.ResultWindowVisible)
            {
                ResultVisible = true;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Save()
        {
            var settings = Properties.Settings.Default;

            var mainWindow = resolver.Resolve<MainWindow>();
            settings.MainWindowPosition = FormatPoint(mainWindow.Left, mainWindow.Top);
            settings.MainWindowSize = FormatPoint(mainWindow.Width, mainWindow.Height);
            settings.MainWindowMaximized = mainWindow.WindowState == WindowState.Maximized;

            settings.OperationWindowVisible = OperationVisible;
            if (operationWindow != null)
            {
                settings.OperationWindowPosition = FormatPoint(operationWindow.Left, operationWindow.Top);
            }

            settings.ResultWindowVisible = ResultVisible;
            if (resultWindow != null)
            {
                settings.ResultWindowPosition = FormatPoint(resultWindow.Left, resultWindow.Top);
            }

            settings.Save();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static string FormatPoint(double x, double y)
        {
            return String.Format(CultureInfo.InvariantCulture, "{0},{1}", x, y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="setter"></param>
        private static void SetPoint(string value, Action<int, int> setter)
        {
            if (String.IsNullOrEmpty(value))
            {
                return;
            }

            var values = value.Split(',');
            if (values.Length != 2)
            {
                return;
            }

            setter(Convert.ToInt32(values[0], CultureInfo.InvariantCulture), Convert.ToInt32(values[1], CultureInfo.InvariantCulture));
        }
    }
}

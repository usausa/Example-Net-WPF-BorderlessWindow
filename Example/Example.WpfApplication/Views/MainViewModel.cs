namespace Example.WpfApplication.Views
{
    /// <summary>
    ///
    /// </summary>
    public class MainViewModel
    {
        public IWindowManager WindowManager { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="windowManager"></param>
        public MainViewModel(IWindowManager windowManager)
        {
            WindowManager = windowManager;
        }
    }
}

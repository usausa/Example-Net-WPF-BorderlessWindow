namespace Example.WpfApplication.Views
{
    using Smart.Windows.ViewModels;

    /// <summary>
    ///
    /// </summary>
    public class ResultViewModel : ViewModelBase
    {
        private readonly IWindowManager windowManager;

        /// <summary>
        ///
        /// </summary>
        /// <param name="windowManager"></param>
        public ResultViewModel(IWindowManager windowManager)
        {
            this.windowManager = windowManager;
        }

        /// <summary>
        ///
        /// </summary>
        public void Hide()
        {
            windowManager.OperationVisible = false;
        }
    }
}

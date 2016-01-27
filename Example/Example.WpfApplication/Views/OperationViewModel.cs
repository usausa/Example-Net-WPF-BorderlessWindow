namespace Example.WpfApplication.Views
{
    using Smart.Windows.ViewModels;

    /// <summary>
    ///
    /// </summary>
    public class OperationViewModel : ViewModelBase
    {
        private readonly IWindowManager windowManager;

        /// <summary>
        ///
        /// </summary>
        /// <param name="windowManager"></param>
        public OperationViewModel(IWindowManager windowManager)
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

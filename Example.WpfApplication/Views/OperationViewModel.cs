namespace Example.WpfApplication.Views
{
    using Example.WpfApplication.Models;

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
        public Counter Counter { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="windowManager"></param>
        /// <param name="counter"></param>
        public OperationViewModel(IWindowManager windowManager, Counter counter)
        {
            this.windowManager = windowManager;
            Counter = counter;
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

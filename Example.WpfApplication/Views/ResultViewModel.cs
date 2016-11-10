namespace Example.WpfApplication.Views
{
    using System.Globalization;

    using Example.WpfApplication.Models;

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
        public Counter Counter { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="windowManager"></param>
        /// <param name="counter"></param>
        public ResultViewModel(IWindowManager windowManager, Counter counter)
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

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public string Copy()
        {
            return Counter.Count.ToString(CultureInfo.InvariantCulture);
        }
    }
}

namespace Example.WpfApplication.Views
{
    /// <summary>
    /// OperationWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class OperationWindow
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="vm"></param>
        public OperationWindow(OperationViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}

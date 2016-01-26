namespace Example.WpfApplication.Views
{
    /// <summary>
    /// ResultWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ResultWindow
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="vm"></param>
        public ResultWindow(ResultViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}

namespace Example.WpfApplication.Models
{
    using Smart.ComponentModel;

    /// <summary>
    ///
    /// </summary>
    public class ApplicationModel : NotificationObject
    {
        private int counter;

        /// <summary>
        ///
        /// </summary>
        public int Counter
        {
            get { return counter; }
            private set { SetProperty(ref counter, value); }
        }

        /// <summary>
        ///
        /// </summary>
        public void Reset()
        {
            Counter = 0;
        }

        /// <summary>
        ///
        /// </summary>
        public void Increment()
        {
            Counter++;
        }

        /// <summary>
        ///
        /// </summary>
        public void Decrement()
        {
            if (Counter > 0)
            {
                Counter--;
            }
        }
    }
}

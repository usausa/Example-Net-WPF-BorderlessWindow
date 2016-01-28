namespace Example.WpfApplication.Models
{
    using Smart.ComponentModel;

    /// <summary>
    ///
    /// </summary>
    public class Counter : NotificationObject
    {
        private readonly int max;

        private int count;

        /// <summary>
        ///
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool EnableIncrement
        {
            get { return count < max; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool EnableDecrement
        {
            get { return count > 0; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="max"></param>
        public Counter(int max)
        {
            this.max = max;
        }

        /// <summary>
        ///
        /// </summary>
        public void Reset()
        {
            count = 0;
            Update();
        }

        /// <summary>
        ///
        /// </summary>
        public void Increment()
        {
            if (EnableIncrement)
            {
                count++;
                Update();
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Decrement()
        {
            if (EnableDecrement)
            {
                count--;
                Update();
            }
        }

        /// <summary>
        ///
        /// </summary>
        private void Update()
        {
            RaisePropertyChanged(nameof(Count));
            RaisePropertyChanged(nameof(EnableIncrement));
            RaisePropertyChanged(nameof(EnableDecrement));
        }
    }
}

namespace UnoCanvasOffsetAnimationIssue
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    ///  The main view model.
    /// </summary>
    [Bindable(true)]
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The x co-ordinate
        /// </summary>
        private double x;

        /// <summary>
        /// Gets the y co-ordinate
        /// </summary>
        private double y;

        /// <summary>
        /// True if the size has been set.
        /// </summary>
        private bool sizeIsSet;

        /// <summary>
        /// True if the page has been loaded.
        /// </summary>
        private bool isLoaded;

        /// <summary>
        /// A locking object
        /// </summary>
        private object lockingObject = new object();

        #region [ INotifyPropertyChanged Events ]

        /// <summary>
        ///  Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        /// <summary>
        /// Gets the x co-ordinate
        /// </summary>
        public double X
        {
            get
            {
                return this.x;
            }

            private set
            {
                if (value != this.x)
                {
                    this.x = value;
                    this.OnPropertyChanged("X");
                }
            }
        }

        /// <summary>
        /// Gets the y co-ordinate
        /// </summary>
        public double Y
        {
            get
            {
                return this.y;
            }

            private set
            {
                if (value != this.y)
                {
                    this.y = value;
                    this.OnPropertyChanged("Y");
                }
            }
        }

        /// <summary>
        /// Called when a property value has changed
        /// </summary>
        /// <param name="propertyName">The name of the property that changed</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            // Thread marshalling not required in this sample - removed for simplicity.
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Called when the page is loaded
        /// </summary>
        /// <param name="actualWidth">The actual width of the canvas</param>
        /// <param name="actualHeight">The actual height of the canvas</param>
        public void OnLoad(double actualWidth, double actualHeight)
        {
            lock (this.lockingObject)
            {
                this.isLoaded = true;
                if (actualWidth > 0 && actualHeight > 0)
                {
                    this.OnSizeSet(actualWidth, actualHeight);
                }
            }
        }

        /// <summary>
        /// Called when the page is resized.
        /// </summary>
        /// <param name="actualWidth">The actual width of the canvas</param>
        /// <param name="actualHeight">The actual height of the canvas</param>
        public void OnSizeChanged(double actualWidth, double actualHeight)
        {
            lock (this.lockingObject)
            {
                if (!this.sizeIsSet && this.isLoaded && actualWidth > 0 && actualHeight > 0)
                {
                    this.OnSizeSet(actualWidth, actualHeight);
                }
            }
        }

        /// <summary>
        /// Formats a co-ordinate
        /// </summary>
        /// <param name="coord">The input value</param>
        /// <returns></returns>
        public string AsString(double coord)
        {
            return String.Format("{0:0.#}", coord);
        }

        /// <summary>
        /// Called when a non zero canvas size has been set on or after page load.
        /// </summary>
        /// <param name="actualWidth">The actual width of the canvas</param>
        /// <param name="actualHeight">The actual height of the canvas</param>
        private void OnSizeSet(double actualWidth, double actualHeight)
        {
            this.sizeIsSet = true;

            this.X = (actualWidth / 2.0);
            this.Y = actualHeight;
        }
    }
}

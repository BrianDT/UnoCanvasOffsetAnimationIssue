
namespace UnoCanvasOffsetAnimationIssue
{
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;

    public sealed partial class MainPage : Page
    {
        #region [ Constructor ]

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            this.DataContext = new MainViewModel();

            this.Loaded += this.OnLoaded;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets the view model, used as a binding prefix.
        /// </summary>
        public MainViewModel VM
        {
            get
            {
                return this.DataContext as MainViewModel;
            }
        }

        #endregion

        /// <summary>
        /// Loaded event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void OnLoaded(object sender, object e)
        {
            this.VM.OnLoad(this.Map.ActualWidth, this.Map.ActualHeight);
        }

        /// <summary>
        /// Event handler for grid size change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.VM.OnSizeChanged(this.Map.ActualWidth, this.Map.ActualHeight);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this.Simple.IsEnabled = false;
            this.SimpleStoryboard.Begin();
        }
    }
}
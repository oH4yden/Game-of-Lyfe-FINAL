using System.Windows;


namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Loaded += OnLoad;

        }
        // the navigation to the page of the game
        public void PlayGame()
        {
            Page1 pg1 = new Page1();
            this.Content = pg1;

        }
        // the button for PLAY! 
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            PlayGame();
        }
        /*
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering += Test;
        }

        protected void Test(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("hello");
        }
        */
    }
}

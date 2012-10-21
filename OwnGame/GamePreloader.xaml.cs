using System.Windows;

namespace OwnGame
{
    /// <summary>
    /// Interaction logic for GameInitialization.xaml
    /// </summary>
    public partial class GamePreloader : Window
    {
        public GamePreloader()
        {
            InitializeComponent();

            DataContext = new GamePreloaderViewModel();
        }
    }
}

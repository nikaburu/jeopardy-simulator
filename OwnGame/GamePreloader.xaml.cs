using System;
using System.Diagnostics;
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

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHAndler);
        }

        private void ExceptionHAndler(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (Exception)e.ExceptionObject;
            string message = exception.Message;
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                message += ";\t\n" + exception.Message;
            }

            Trace.TraceError(message);
            MessageBox.Show(message);
        }
    }
}

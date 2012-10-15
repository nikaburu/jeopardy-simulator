using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Messages;

namespace OwnGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Messenger.Default.Register<ChangeMasterDetailStateMessage>(this, ChangeMasterDetailState);
        }

        private void ChangeMasterDetailState(ChangeMasterDetailStateMessage message)
        {
            questionTableView.Visibility = questionProcessView.Visibility;
            questionProcessView.Visibility = RevertVisibility(questionProcessView.Visibility);
        }

        private static Visibility RevertVisibility(Visibility visibility)
        {
            return Visibility.Collapsed.Equals(visibility) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}

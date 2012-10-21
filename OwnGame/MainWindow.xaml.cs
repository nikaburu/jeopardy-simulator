﻿using System;
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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Infrastructure;
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
            ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModelLocator());
            InitializeComponent();

            Messenger.Default.Register<LoadQuestionMessage>(this, ChangeMasterDetailState);
            Messenger.Default.Register<UnloadQuestionMessage>(this, ChangeMasterDetailState);

            Messenger.Default.Register<GameEndedMessage>(this, ShowResults);
        }

        private void ChangeMasterDetailState(MessageBase message)
        {
            if (questionTableView.Visibility != questionProcessView.Visibility)
            {
                questionTableView.Visibility = questionProcessView.Visibility;
                questionProcessView.Visibility = RevertVisibility(questionProcessView.Visibility);
            }
        }

        private static Visibility RevertVisibility(Visibility visibility)
        {
            return Visibility.Collapsed.Equals(visibility) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ShowResults(MessageBase message)
        {
            questionTableView.Visibility = Visibility.Collapsed;
            questionProcessView.Visibility = Visibility.Collapsed;
            resultsWindowView.Visibility = Visibility.Collapsed;
            
            resultsView.Visibility = Visibility.Visible;
        }
    }
}

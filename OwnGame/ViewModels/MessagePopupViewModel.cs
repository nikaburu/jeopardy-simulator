using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Commands;
using OwnGame.Messages;
using OwnGame.Models;

namespace OwnGame.ViewModels
{
    public class MessagePopupViewModel : ViewModelBase
    {
        private bool _isActive;
        private ChangeScoreCommand _command;
        private int _score;

        public MessagePopupViewModel()
        {
            ProcessCommand = new RelayCommand(() =>
                                                  {
                                                      IsActive = false;
                                                      _command.Execute(_score);
                                                  });

            CloseCommand = new RelayCommand(() =>
                                                {
                                                    IsActive = false;
                                                });

            Messenger.Default.Register<PopupActivateMessage>(this, OnPopupActivate);
        }

        private void OnPopupActivate(PopupActivateMessage message)
        {
            _command = message.Content.Item1;
            _score = message.Content.Item2;

            IsActive = true;

            //todo configure message
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                RaisePropertyChanged(() => IsActive);
            }
        }

        public RelayCommand ProcessCommand { get; private set; }
        public RelayCommand CloseCommand { get; private set; }
    }
}
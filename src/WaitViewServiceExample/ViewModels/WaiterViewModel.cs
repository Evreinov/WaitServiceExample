using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace WaitViewServiceExample.ViewModels
{
    public class WaiterViewModel : ObservableObject
    {
        #region Message : string - Сообщение о прогрессе

        /// <summary>Сообщение о прогрессе</summary>
        private string? _message = "In Progress...";

        /// <summary>Сообщение о прогрессе</summary>
        public string? Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        #endregion
    }
}

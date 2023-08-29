using CommunityToolkit.Mvvm.ComponentModel;

namespace WaitServiceExample.ViewModels
{
    class WaitViewModel : ObservableObject
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

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WaitViewServiceExample.Models;
using WaitViewServiceExample.Services;

namespace WaitViewServiceExample.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        public Action<string>? Message;

        #region StartCommand

        public ICommand StartCommand { get; }

        private async void OnStartCommandExecuted()
        {
            CurrentViewModel = new WaiterViewModel();
            var service = new WaitService<IEnumerable<Entity>>(Work, this);
            var result = await service.DoWork();
            CurrentViewModel = new TableViewModel
            {
                Entities = new ObservableCollection<Entity>(result),
            };
            
        }

        #endregion

        #region CurrentViewModel : CurrentViewModel - Текущая модель представления

        /// <summary>Текущая модель представления</summary>
        private ObservableObject? _currentViewModel;

        /// <summary>Текущая модель представления</summary>
        public ObservableObject? CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        #endregion

        public MainViewModel()
        {
            StartCommand = new RelayCommand(OnStartCommandExecuted);
        }

        private IEnumerable<Entity> Work()
        {
            var collection = new List<Entity>();
            for (var i = 0; i <= 100; i++)
            {
                Message?.Invoke($"Получаю данные для узла {i}");
                collection.Add(new Entity
                {
                    Id = i,
                    Name = $"Наименование {i}",
                });
                // Эмулируем продолжительную работу.
                Thread.Sleep(20);
            }
            return collection;
        }
    }
}

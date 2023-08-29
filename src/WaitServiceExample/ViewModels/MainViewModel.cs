using System;
using WaitServiceExample.Models;
using WaitServiceExample.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;

namespace WaitServiceExample.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public Action<string>? Message;

        #region StartCommand

        public ICommand StartCommand { get; }

        private async void OnStartCommandExecuted()
        {
            var service = new WaitService<IEnumerable<Node>>(Work, this);
            var result = await service.DoWork();
            Nodes = new ObservableCollection<Node>(result);
        }

        #endregion

        #region Nodes

        private ObservableCollection<Node> _nodes;

        public ObservableCollection<Node> Nodes
        {
            get => _nodes;
            private set => SetProperty(ref _nodes, value);
        } 

        #endregion

        public MainViewModel()
        {
            _nodes = new ObservableCollection<Node>();
            StartCommand = new RelayCommand(OnStartCommandExecuted);
        }

        private IEnumerable<Node> Work()
        {
            var collection = new List<Node>();
            for (var i = 0; i <= 100; i++)
            {
                Message?.Invoke($"Получаю данные для узла {i}");
                collection.Add(new Node
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

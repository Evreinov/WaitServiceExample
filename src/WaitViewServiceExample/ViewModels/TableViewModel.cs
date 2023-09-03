using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WaitViewServiceExample.Models;

namespace WaitViewServiceExample.ViewModels
{
    public class TableViewModel : ObservableObject
    {
        #region Entities

        private ObservableCollection<Entity> _entities = new();

        public ObservableCollection<Entity> Entities
        {
            get => _entities;
            set => SetProperty(ref _entities, value);
        }

        #endregion
    }
}

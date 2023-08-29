using WaitServiceExample.ViewModels;
using WaitServiceExample.Views;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace WaitServiceExample.Services
{
    internal class WaitService<T> : IWaitService<T>
    {
        private Func<T> Worker { get; }

        private Window Window { get; }

        public WaitService(Func<T> worker, object sender)
        {
            var context = new WaitViewModel();
            Window = new WaitWindow
            {
                DataContext = context,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };
            Window.Show();
            if (sender is MainViewModel castSender)
            {
                castSender.Message += s => context.Message = s;
            }
            Worker = worker ?? throw new ArgumentException();
        }

        public Task<T> DoWork()
        {
            return Task<T>.Factory.StartNew(Worker).ContinueWith(t => 
            {
                Window.Close();
                return t.Result;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}

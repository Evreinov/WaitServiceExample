using System;
using System.Threading.Tasks;
using WaitViewServiceExample.ViewModels;

namespace WaitViewServiceExample.Services
{
    internal class WaitService<T>
    {
        private Func<T> Worker { get; }

        private MainViewModel MainViewModel { get; }

        public WaitService(Func<T> worker, object sender)
        {
            if (sender is MainViewModel castSender)
            {
                MainViewModel = castSender;
                if (MainViewModel.CurrentViewModel is WaiterViewModel context)
                {
                    MainViewModel.Message += s => context.Message = s;
                }
            }
            Worker = worker ?? throw new ArgumentException();
        }

        public Task<T> DoWork()
        {
            return Task<T>.Factory.StartNew(Worker).ContinueWith(t => t.Result, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}

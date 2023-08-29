using System.Threading.Tasks;

namespace WaitServiceExample.Services
{
    public interface IWaitService<T>
    {
        Task<T> DoWork();
    }
}
using System.Threading.Tasks;

namespace ConsoleApp.Core
{
    public interface IGreetingService
    {
        Task<bool> RunAsync();
    }
}
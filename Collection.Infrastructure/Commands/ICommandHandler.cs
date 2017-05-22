using System.Threading.Tasks;

namespace Collection.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}

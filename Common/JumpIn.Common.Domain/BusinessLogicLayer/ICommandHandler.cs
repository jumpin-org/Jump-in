using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Common.Domain.BusinessLogicLayer
{
    public interface ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        Task<TResult> Execute(TCommand command);
    }

    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task Execute(TCommand command);
    }

    public interface ICommandHandler
    {
        Task Execute();
    }

    public interface IDeleteCommandHandler
    {
        Task Delete(int id);
    }
}

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
        Task<TResult> Handle(TCommand command);
    }

    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }

    public interface ICommandHandler
    {
        Task Handle();
    }

    public interface IDeleteCommandHandler
    {
        Task Delete(int id);
    }
}

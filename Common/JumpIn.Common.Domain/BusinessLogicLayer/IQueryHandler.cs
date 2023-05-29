namespace JumpIn.Common.Domain.BusinessLogicLayer
{
    public interface IQueryHandler<TQuery, out TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }

    public interface IQueryHandler<out TResult>
    {
        TResult Handle();
    }
}

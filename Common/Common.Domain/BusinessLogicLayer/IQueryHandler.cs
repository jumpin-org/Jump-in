namespace JumpIn.Common.Domain.BusinessLogicLayer
{
    public interface IQueryHandler<TQuery, out TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Execute(TQuery query);
    }

    public interface IQueryHandler<out TResult>
    {
        TResult Execute();
    }
}

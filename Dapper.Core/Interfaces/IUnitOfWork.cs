namespace Dapper.Core.Interfaces
{
    public  interface IUnitOfWork
    {
        IProductRepository Products { get; }
    }
}
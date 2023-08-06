using Dapper.Core.Interfaces;

namespace Dapper.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IProductRepository products)
        {
            Products = products;
        }

        public IProductRepository Products { get; }
    }
}

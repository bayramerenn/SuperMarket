namespace SuperMarket.DataAccess.Repositories.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IProductRepository Products { get; }
        IBasketRepository Baskets { get; }
        IInvoiceRepository Invoices { get; }

        Task<int> SaveAsync();
    }
}
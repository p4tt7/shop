public interface IProductRepository
{
    Task<PagedResponse<Product>> GetAll(int pageSize, int page);
    Task<Product> GetProduct(Guid id);
}
public interface IProductRepository
{
    Task<PagedResponse<Product>> GetAll(int pageSize, int page);
    Task<Product> GetProduct(Guid id);
    Task<PagedResponse<Product>> GetByCategory(Guid id, int pageSize, int page);
}
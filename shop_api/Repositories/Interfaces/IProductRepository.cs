public interface IProductRepository
{
    Task<PagedResponse<Product>> GetAll(int start, int pageSize);
}
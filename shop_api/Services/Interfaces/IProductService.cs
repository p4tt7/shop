public interface IProductService
{
    Task<PagedResponse<Product>> GetAll(int pageSize, int page);
    Task<ProductResponse> GetProduct(Guid id);
}
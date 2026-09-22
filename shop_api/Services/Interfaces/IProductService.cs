public interface IProductService
{
    Task<PagedResponse<ProductResponse>> GetAll(int pageSize, int page);
    Task<ProductResponse> GetProduct(Guid id);
    Task<PagedResponse<ProductResponse>> GetByCategory(Guid id, int pageSize, int page);
}
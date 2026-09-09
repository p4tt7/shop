public class ProductService : IProductService
{
    readonly IProductRepository _repo;
    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Product>> GetAll(int pageSize, int page)
    {
        var pagedResponse = await _repo.GetAll(page, pageSize);
        return pagedResponse.Items;
    }
}
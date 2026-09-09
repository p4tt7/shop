using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductRepository
{
    private readonly ShopDbContext _db;
    public ProductRepository(ShopDbContext db)
    {
        _db = db;
    }
    public async Task<PagedResponse<Product>> GetAll(int page, int pageSize)
    {
        var products = await _db.Products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        int totalItems = await _db.Products.CountAsync();
        return new PagedResponse<Product>
        {
            Items = products,
            TotalItems = totalItems,
            Page = page,
            PageSize = pageSize
        };
        
    }

}
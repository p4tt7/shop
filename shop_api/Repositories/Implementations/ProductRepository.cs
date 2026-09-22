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

    public async Task<Product> GetProduct(Guid id)
    {
        var product = await _db.Products
        .Include(p => p.Category)
        .Include(p => p.Images)
        .Include(p => p.Reviews)
            .ThenInclude(r => r.Reviewer)
        .FirstOrDefaultAsync(p => p.Id == id);

        return product;
    }

    public async Task<PagedResponse<Product>> GetByCategory(Guid id, int pageSize, int page)
    {
        var categoryProducts = await _db.Products
            .Where(p => p.CategoryId == id)
            .ToListAsync();

        return new PagedResponse<Product>
        {
            Items = categoryProducts,
            TotalItems = categoryProducts.Count,
            Page = page,
            PageSize = pageSize
        };
    }
}
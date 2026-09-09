public interface IProductService
{
    Task<IEnumerable<Product>> GetAll(int pageSize, int page);
}
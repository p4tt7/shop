public class ProductService : IProductService
{
    readonly IProductRepository _repo;
    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<PagedResponse<Product>> GetAll(int page, int pageSize)
    {
        var pagedResponse = await _repo.GetAll(page, pageSize);
        return pagedResponse;
    }

    public async Task<ProductResponse> GetProduct(Guid id)
    {
        var product = await _repo.GetProduct(id);

        List<ImageResponse> ImagesResponse = new List<ImageResponse>();
        List<ReviewResponse> ReviewsResponse = new List<ReviewResponse>();

        foreach (var img in product.Images)
        {
            ImageResponse ImgResp = new ImageResponse
            {
                Id = img.Id,
                URL = img.URL
            };

            ImagesResponse.Add(ImgResp);
        }

        foreach (var rev in product.Reviews)
        {
            ReviewResponse RevRsp = new ReviewResponse
            {
                Id = rev.Id,
                ReviewText = rev.ReviewText,
                Rating = rev.Rating,
                UserId = rev.UserId,
                Reviewer = rev.Reviewer.Username
            };

            ReviewsResponse.Add(RevRsp);
        }

        return new ProductResponse
        {
            Id = id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = new CategoryResponse
            {
                Id = product.CategoryId,
                Name = product.Category.Name
            },
            Images = ImagesResponse,
            Reviews = ReviewsResponse
        };
    }
}
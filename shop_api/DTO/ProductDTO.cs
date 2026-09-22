public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public CategoryResponse Category { get; set; } = null!;
    public ICollection<ImageResponse> Images { get; set; } = null!;
    public ICollection<ReviewResponse> Reviews { get; set; } = null!;
}

public class ProductRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public List<Guid> ImagesId { get; set; } = null!;
}

public class CategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class ImageResponse
{
    public Guid Id { get; set; }
    public string URL { get; set; } = string.Empty;
}

public class ReviewResponse
{
    public Guid Id { get; set; }
    public string ReviewText { get; set; } = string.Empty;
    public int Rating { get; set; }
    public Guid UserId { get; set; }
    public string Reviewer { get; set; } = null!;
}
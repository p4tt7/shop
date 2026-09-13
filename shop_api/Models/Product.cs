public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}

public class Review
{
    public Guid Id {get; set;} = Guid.NewGuid();
    public string ReviewText { get; set; } = string.Empty;
    public int Rating { get; set; }

    public Product ProductReview {get; set;} = null!;
    public Guid ProductId {get; set;}

    public Guid UserId {get; set;}
    public User Reviewer { get; set; } = null!;

}




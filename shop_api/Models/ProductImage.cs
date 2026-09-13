public class ProductImage
{
    public Product ImageProduct {get; set;} = null!;
    public Guid ProductId {get; set;}
    public Guid Id {get; set;} 
    public string URL {get; set;} = string.Empty;
}
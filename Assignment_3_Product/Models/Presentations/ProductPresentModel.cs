namespace Assignment_3_Product.Models;

public class ProductPresentModel
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Manufacture { get; set; }
    public Guid CategoryId { get; set; }
}
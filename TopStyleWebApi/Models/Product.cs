namespace TopStyleWebApi.Models;

public class Product : BaseEntity
{
    public float Price { get; set; }
    public string Name { get; set; }="";
    public string Description { get; set; }="";
    public string Image { get; set; }="";
    
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = new Category();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
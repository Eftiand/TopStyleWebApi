namespace TopStyleWebApi.Models;

public class Order : BaseEntity
{
    public float TotalPrice { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }  = new User();
    public virtual ICollection<Product> Products { get; set; }  = new List<Product>();
}

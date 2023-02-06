namespace TopStyleWebApi.Models.RecievingClasses;

public class TemplateOrder
{
    public float TotalPrice { get; set; }
    public int UserId { get; set; }
    public List<int> Products { get; set; } = new List<int>();
}
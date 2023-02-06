using System.ComponentModel.DataAnnotations;

namespace TopStyleWebApi.Models;

public class Category : BaseEntity
{
    [StringLength(20)]
    public string Name { get; set; } ="";
}
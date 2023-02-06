using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TopStyleWebApi.Models;

public class User : BaseEntity
{
    [StringLength(50)]
    public string UserName { get; set; } ="";
    [StringLength(50)]
    public string Password { get; set; }="";
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace lastLab.DataBase.Models;

public class CustomUser : IdentityUser
{
    [Column(TypeName = "date")]
    public DateTime DateOfBirth { get; set; }
}

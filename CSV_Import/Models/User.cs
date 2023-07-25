using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSV_Import.Models;

public class User
{
    [Key]
    public int UserIdentifier { get; set; }
    public string UserName { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    
}
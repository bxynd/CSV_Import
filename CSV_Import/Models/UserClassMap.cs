using CsvHelper.Configuration;

namespace CSV_Import.Models;

public class UserClassMap: ClassMap<User>
{
    public UserClassMap()
    {
        Map(p => p.UserName).Name("username");
        Map(p => p.UserIdentifier).Name("useridentifier");
        Map(p => p.Age).Name("age");
        Map(p => p.City).Name("city");
        Map(p => p.PhoneNumber).Name("phonenumber");
        Map(p => p.Email).Name("email");
    }
}
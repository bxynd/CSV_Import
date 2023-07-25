using System.Globalization;
using System.Runtime.CompilerServices;
using CSV_Import.Models;
using CSV_Import.Repositories;
using CsvHelper;

namespace CSV_Import.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    
    public async Task<int> AddUsers(IFormFile file)
    {
        //read file from stream and parse it using csvhelper
        var reader = new StreamReader(file.OpenReadStream());
        var csv = new CsvReader(reader, CultureInfo.GetCultureInfo("en-GB"));
        csv.Context.RegisterClassMap<UserClassMap>();
        var records = csv.GetRecords<User>().ToList();
        
        return await _userRepository.Create(records);
    }

    public async Task<List<User>> GetUsers(int limit, int offset,bool asc)
    {
        return await _userRepository.ReadPaginated(limit,offset-1,asc);
    }
}
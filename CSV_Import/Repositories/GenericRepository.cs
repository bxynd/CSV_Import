using CSV_Import.Context;
using CSV_Import.Models;
using Microsoft.EntityFrameworkCore;

namespace CSV_Import.Repositories;

public class GenericRepository<T>: IGenericRepository<T> where T : class
{
    private readonly IDataContext _dataContext;
    private readonly DbSet<T> dbSet;

    public GenericRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
        dbSet = _dataContext.Set<T>();
    }
    public async Task<int> Create(List<T> users)
    {
        var updateList = new List<T>();
        foreach (var user in users)
        {
            if (dbSet.Contains(user))
            {
                updateList.Add(user);
            }
        }
        await Task.Run(() => dbSet.UpdateRange(updateList));
        
        await dbSet.AddRangeAsync(users.Except(updateList));
        
        return await _dataContext.ContextSaveChanges();
    }
}
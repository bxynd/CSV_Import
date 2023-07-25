using CSV_Import.Models;

namespace CSV_Import.Context;

using Microsoft.EntityFrameworkCore;
public class DataContext: DbContext, IDataContext
{
    
    public DbSet<User> Users { get; set; }
    public Task<int> ContextSaveChanges()
    {
        return base.SaveChangesAsync();
    }
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }
}
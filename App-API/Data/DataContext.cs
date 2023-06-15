using Microsoft.EntityFrameworkCore;

namespace App_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //Representation of the dh, <class>, nameofthetable, set= initialization
        public DbSet<Actor> actors => Set<Actor>();
    }
}

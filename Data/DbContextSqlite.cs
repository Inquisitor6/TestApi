using Microsoft.EntityFrameworkCore;
using PruebaEdenred.Model.Db;

namespace PruebaEdenred.Data
{
    public class DbContextSqlite : DbContext
    {
        public DbContextSqlite(DbContextOptions<DbContextSqlite> options)
           : base(options)
        {

        }
        public DbSet<Client> client { get; set; }


    }
}

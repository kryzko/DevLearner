using DevLearner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DevLearner
{
    public class MyDbContext : DbContext
    {
        public DbSet<UsersInfo> Users { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            //try
            //{
            //    var dbcreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            //    if (dbcreator != null)
            //    {
            //        if (!dbcreator.CanConnect())
            //        {
            //            dbcreator.Create();
            //        }
            //        if (!dbcreator.HasTables())
            //        {
            //            dbcreator.CreateTables();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}

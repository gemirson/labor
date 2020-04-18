using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;



namespace labor.Infaestructure.EntityFrameworkCoreDataAccess.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<DBContext>
    {
        public DBContext CreateDbContext(string[] args)
        {
               // Get connection string
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            //var connectionString = config.GetConnectionString("DefaultConnection");
            var connectionString = "Host=ec2-54-157-78-113.compute-1.amazonaws.com;Port=5432;Database=d557goe8gb7lva;Username=fkbljtfaxbwanm;Password=f3138826d9bcbccd76556118caa42e372e74a3dc80edd6f1ee7435c24b798cb6;SSL Mode=Require; Trust Server Certificate=true;";


            object p = optionsBuilder.UseNpgsql(connectionString, b => b.MigrationsAssembly("BoostBusiness.APIs.CRUD.Data"));

            return new DBContext(optionsBuilder.Options);
        }
    }
}

using labor.Domain.BrandsE;
using labor.Domain.ModelsE;
using labor.Domain.VehiclesE;
using Microsoft.EntityFrameworkCore;


namespace labor.Infaestructure.EntityFrameworkCoreDataAccess.Context
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Vehicle> Vehicles{ get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                         .ToTable("Brand");

            modelBuilder.Entity<Model>()
                        .ToTable("Model");

            modelBuilder.Entity<Vehicle>()
                        .ToTable("Vehicles");

           
        }
    }
}

using FluentValidation.Results;
using labor.Domain.BaseEntity;
using labor.Domain.BrandsE;
using labor.Domain.ModelsE;
using labor.Domain.VehiclesE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



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

           modelBuilder.Entity<Brand>(BrandConfig).Ignore<ValidationResult>(); ;


           modelBuilder.Entity<Model>(ModelConfig).Ignore<ValidationResult>(); ;

    
           modelBuilder.Entity<Vehicle>(VehicleConfig).Ignore<ValidationResult>();

            modelBuilder.Ignore<Entity>();

            modelBuilder.Ignore<ValidationFailure>();

        }

        private void BrandConfig(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);
            
    
  
        }

        private void ModelConfig(EntityTypeBuilder<Model> builder)
        {
            

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder.HasOne<Brand>()
                   .WithMany()
                   .HasForeignKey(p => p.BrandId).HasPrincipalKey(x => x.Id);
                   

        }

        private void VehicleConfig(EntityTypeBuilder<Vehicle> builder) 
        {
           

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.HasOne<Brand>()
                   .WithMany()
                   .HasForeignKey(p => p.BrandId);

            builder.HasOne<Model>()
                   .WithMany()
                   .HasForeignKey(p => p.ModelsId);

            builder.Property(x => x.Value)
                   .IsRequired();

            builder.Property(x => x.YearModel)
                   .IsRequired()
                   .HasMaxLength(10);


        }
    }
}

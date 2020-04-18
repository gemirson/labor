﻿using labor.Domain.BaseEntity;
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

            modelBuilder.Entity<Brand>(BrandConfig);


            modelBuilder.Entity<Model>(ModelConfig);


            modelBuilder.Entity<Vehicle>(VehicleConfig);

            modelBuilder.Ignore<Entity>();

        }

        private void BrandConfig(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(60);
  
        }

        private void ModelConfig(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(60);
            builder.HasOne<Brand>()
                   .WithMany()
                   .HasForeignKey(p => p.BrandId);

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

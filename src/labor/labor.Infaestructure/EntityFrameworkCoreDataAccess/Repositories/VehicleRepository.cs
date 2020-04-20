using labor.Application.Repositories;
using labor.Domain.Specifications;
using labor.Domain.VehiclesE;
using labor.Infaestructure.EntityFrameworkCoreDataAccess.Context;
using labor.Infaestructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace labor.Infaestructure.EntityFrameworkCoreDataAccess.Repositories
{
    public class VehicleRepository : IVehiclesWriteOnlyRepository, IVehiclesReadOnlyRepository, IDisposable
    {
        private readonly DBContext context;

        public VehicleRepository(DBContext _context)
        {
            this.context = _context;
        }
        public async Task<int> Add(Vehicle vehicles)
        {
            var result = await context.AddAsync(vehicles);
            await context.SaveChangesAsync().ConfigureAwait(true);
            return result.Entity.Id;
        }
    

        public async  Task<int> Delete(int IdVehicle)
        {
            string query_string_delete =
                    @"DELETE FROM Vehicle WHERE Id = @Id";

            var id = new SqlParameter("@Id", IdVehicle);

            int affectedRows = await context.Database.ExecuteSqlRawAsync(
               query_string_delete, id).ConfigureAwait(true);

            return affectedRows;
        }

        public async Task<Vehicle> Get(int id)
        {
            return await context.Vehicles.FindAsync(id);
        }

        public async Task<IReadOnlyList<Vehicle>> GetAll()
        {
            return await context.Vehicles.ToListAsync().ConfigureAwait(true);
        }

        public  async Task<IReadOnlyList<Vehicle>> GetByModel(ISpecification<Vehicle> specification)
        {
            return await ApplySpecification(specification).ToListAsync().ConfigureAwait(true);
        }

        public async Task<int> Update(Vehicle vehicles)
        {
           
            context.Entry(vehicles).State = EntityState.Modified;
            await context.SaveChangesAsync().ConfigureAwait(true);
            return context.Entry(vehicles).Entity.Id;
        }

        private IQueryable<Vehicle> ApplySpecification(ISpecification<Vehicle> spec)
        {
            return SpecificationEvaluator<Vehicle>.GetQuery(context.Set<Vehicle>().AsQueryable(), spec);
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

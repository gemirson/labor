using labor.Application.Command.Brands.Result;
using labor.Application.Queries.Vehicles;
using labor.Domain.Specifications;
using labor.Domain.VehiclesE;
using labor.Infaestructure.EntityFrameworkCoreDataAccess.Context;
using labor.Infaestructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor.Infaestructure.EntityFrameworkCoreDataAccess.Queries
{
    public class VehicleQueries : IVehicleQueries
    {
        private readonly DBContext context;

        public VehicleQueries(DBContext context)
        {
            this.context = context;
        }

        public async Task<Vehicle> Get(int Id)
        {
            return await context.Vehicles.FindAsync(Id);
        }

        public async  Task<IReadOnlyList<Vehicle>> GetVehicleByModel(ISpecification<Vehicle> specification)
        {
            return await ApplySpecification(specification).ToListAsync().ConfigureAwait(true);
        }

        private IQueryable<Vehicle> ApplySpecification(ISpecification<Vehicle> spec)
        {
            return SpecificationEvaluator<Vehicle>.GetQuery(context.Set<Vehicle>().AsQueryable(), spec);
        }
    }
}

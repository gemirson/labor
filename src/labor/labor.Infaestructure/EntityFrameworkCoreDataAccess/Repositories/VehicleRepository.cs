using labor.Application.Repositories;
using labor.Application.Specifications;
using labor.Domain.VehiclesE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Infaestructure.EntityFrameworkCoreDataAccess.Repositories
{
    public class VehicleRepository : IVehiclesWriteOnlyRepository, IVehiclesReadOnlyRepository
    {
        public Task<int> Add(Vehicle vehicles)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Vehicle vehicles)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Vehicle>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Vehicle>> GetBy(ISpecification<Vehicle> specification)
        {
            throw new NotImplementedException();
        }

        public Task Update(Vehicle vehicles)
        {
            throw new NotImplementedException();
        }
    }
}

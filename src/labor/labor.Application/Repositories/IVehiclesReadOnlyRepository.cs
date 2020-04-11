using labor.Application.Specifications;
using labor.Domain.VehiclesE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Repositories
{
    public interface IVehiclesReadOnlyRepository
    {
        Task<Vehicle> Get(int id);
        Task<IReadOnlyList<Vehicle>> GetBy(ISpecification<Vehicle> specification);
        Task<IReadOnlyList<Vehicle>> GetAll();
    }
}

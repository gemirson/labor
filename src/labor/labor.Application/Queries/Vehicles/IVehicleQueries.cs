using labor.Domain.Specifications;
using labor.Domain.VehiclesE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace labor.Application.Queries.Vehicles
{
    public  interface IVehicleQueries
    {
        Task<Vehicle> Get(int Id);
        Task<IReadOnlyList<Vehicle>> GetVehicleByModel(ISpecification<Vehicle> specification);
    }
}

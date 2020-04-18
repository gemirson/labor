using labor.Domain.Specifications;
using labor.Domain.VehiclesE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace labor.Application.Repositories
{
    public interface IVehiclesReadOnlyRepository
    {
        Task<Vehicle> Get(int id);
        Task<IReadOnlyList<Vehicle>> GetByModel(ISpecification<Vehicle> specification);
        Task<IReadOnlyList<Vehicle>> GetAll();
    }
}

using labor.Application.Command.Models;
using System.Threading.Tasks;
using labor.Domain.ModelsE;
using labor.Domain.VehiclesE;

namespace labor.Application.Command.Brands
{
    interface IVehicles
    {
        Task<VehiclesResult> VehiclesHandler(Vehicle vehicle);
    }
}

using labor.Application.Command.Brands;
using labor.Application.Command.Models;
using labor.Application.Repositories;
using labor.Domain.BrandsE;
using labor.Domain.ModelsE;
using labor.Domain.VehiclesE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Command.Vehicles
{
    public class VehiclesCommand : IVehicles
    {
        private readonly IVehiclesWriteOnlyRepository vehicleWriteOnlyRepository;

        VehiclesCommand(IVehiclesWriteOnlyRepository _modelWriteOnlyRepository)
        {
            vehicleWriteOnlyRepository = _modelWriteOnlyRepository;
        }

        public async Task<VehiclesResult> VehiclesHandler(Vehicle vehicle)
        {
            var IdResult = await vehicleWriteOnlyRepository.Add(vehicle);
            return new VehiclesResult(IdResult, vehicle.Name);
        }

    }
}

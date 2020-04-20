using labor.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Command.Vehicles.Delete
{
    public class VehicleDeleteCommand : IVehicleDelete
    {
        private readonly IVehiclesWriteOnlyRepository vehicleWriteOnlyRepository;

        public VehicleDeleteCommand(IVehiclesWriteOnlyRepository vehicleWriteOnlyRepository)
        {
            this.vehicleWriteOnlyRepository = vehicleWriteOnlyRepository;
        }

        public async Task<int> Handler(int IdModel)
        {
            var IdResult = await vehicleWriteOnlyRepository.Delete(IdModel);
            return IdResult;
        }
    }
}

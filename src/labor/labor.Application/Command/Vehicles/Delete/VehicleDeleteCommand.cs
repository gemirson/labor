using labor.Application.Helper;
using labor.Application.Repositories;
using labor.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace labor.Application.Command.Vehicles.Delete
{
    public class VehicleDeleteCommand : IRequestHandler<VehicleDeleteViewModel, ResultE>
    {
        private readonly IVehiclesWriteOnlyRepository vehicleWriteOnlyRepository;

        public VehicleDeleteCommand(IVehiclesWriteOnlyRepository vehicleWriteOnlyRepository)
        {
            this.vehicleWriteOnlyRepository = vehicleWriteOnlyRepository;
        }

        public async  Task<ResultE> Handle(VehicleDeleteViewModel request, CancellationToken cancellationToken)
        {
            var IdResult = await vehicleWriteOnlyRepository.Delete(request.Id);
            return new ResultE(new Guid(), request.Id.ToString(), IdResult != -1 ? "VEHICLE DELETED WITH SUCESS": "VEHICLE NOT DELETED") ;
        }

       
    }
}

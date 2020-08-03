using AutoMapper;
using labor.Application.Helper;
using labor.Application.Repositories;
using labor.Application.ViewModel;
using labor.Domain.Notifications;
using labor.Domain.VehiclesE;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace labor.Application.Command.Vehicles.Edit
{
    public class VehicleEditCommand : IRequestHandler<VehicleEditViewModel, ResultE>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IVehiclesWriteOnlyRepository vehicleWriteOnlyRepository;

        public VehicleEditCommand(IMapper mapper, NotificationContext notificationContext, IVehiclesWriteOnlyRepository vehicleWriteOnlyRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            this.vehicleWriteOnlyRepository = vehicleWriteOnlyRepository;
        }

        public async Task<ResultE> Handle(VehicleEditViewModel request, CancellationToken cancellationToken)
        {
            var vehicle = _mapper.Map<VehicleEditViewModel, Vehicle>(request);

            if (vehicle.ValidationResult.IsValid)
            {
                _notificationContext.AddNotifications(vehicle.ValidationResult);
                return new ResultE(new Guid(), vehicle.Name, "VEHICLE NOT EDITED");

            }

            var IdResult = await vehicleWriteOnlyRepository.Update(new Vehicle(vehicle.Name, vehicle.Id, vehicle.BrandId, vehicle.ModelsId, vehicle.Value, vehicle.YearModel, vehicle.Fuel));

            return new ResultE(new Guid(), vehicle.Name, IdResult != -1 ? "VEHICLE EDITED WITH SUCESS" : "VEHICLE NOT EDITED");
        }
              
    }
}

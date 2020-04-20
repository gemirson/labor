using labor.Application.Command.Vehicles.Result;
using labor.Application.ViewModel;
using labor.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Command.Vehicles.Change
{
    interface IVehicleChange
    {
        Task<VehiclesResult> Handler(VehicleViewModel vehicleViewModel, NotificationContext notificationContext);
    }
}

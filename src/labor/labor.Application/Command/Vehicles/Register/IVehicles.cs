using labor.Application.Command.Models;
using System.Threading.Tasks;
using labor.Domain.ModelsE;
using labor.Domain.VehiclesE;
using labor.Application.ViewModel;
using labor.Domain.Notifications;
using labor.Application.Command.Vehicles.Result;

namespace labor.Application.Command.Vehicles.Register
{
    interface IVehicles
    {
        Task<VehiclesResult> Handler(VehicleViewModel vehicleViewModel, NotificationContext notificationContext);
    }

 
}

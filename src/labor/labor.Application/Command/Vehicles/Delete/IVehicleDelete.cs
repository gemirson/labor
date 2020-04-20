using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Command.Vehicles.Delete
{
    interface IVehicleDelete
    {
        Task<int> Handler(int IdModel);
    }
}

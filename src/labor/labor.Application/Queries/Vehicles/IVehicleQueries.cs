using labor.Application.Command.Brands.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Queries.Vehicles
{
    interface IVehicleQueries
    {
        Task<BrandResult> Get(int Id);
    }
}

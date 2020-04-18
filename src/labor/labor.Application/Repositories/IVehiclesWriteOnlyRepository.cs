﻿using labor.Domain.VehiclesE;
using System;
using System.Threading.Tasks;

namespace labor.Application.Repositories
{
    public interface IVehiclesWriteOnlyRepository
    {
        Task<int> Add(Vehicle vehicles);
        Task<int> Update(Vehicle vehicles);
        Task<int> Delete(Vehicle vehicles);
    }

}

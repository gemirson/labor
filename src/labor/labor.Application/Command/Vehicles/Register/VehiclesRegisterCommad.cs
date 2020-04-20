﻿using AutoMapper;
using labor.Application.Command.Brands;
using labor.Application.Command.Models;
using labor.Application.Command.Vehicles.Register;
using labor.Application.Command.Vehicles.Result;
using labor.Application.Repositories;
using labor.Application.ViewModel;
using labor.Domain.BrandsE;
using labor.Domain.ModelsE;
using labor.Domain.Notifications;
using labor.Domain.VehiclesE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Command.Vehicles
{
    public class VehiclesRegisterCommand : IVehicles
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IVehiclesWriteOnlyRepository vehicleWriteOnlyRepository;

        public VehiclesRegisterCommand(IMapper mapper, NotificationContext notificationContext, IVehiclesWriteOnlyRepository vehicleWriteOnlyRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            this.vehicleWriteOnlyRepository = vehicleWriteOnlyRepository;
        }

        public async Task<VehiclesResult> Handler(VehicleViewModel vehicleViewModel, NotificationContext notificationContext)
        {
            var vehicle = _mapper.Map<VehicleViewModel, Vehicle>(vehicleViewModel);

            if (vehicle.ValidationResult.IsValid)
            {
                _notificationContext.AddNotifications(vehicle.ValidationResult);
                return new VehiclesResult(-1, vehicle.Name, "NOK");

            }

            var IdResult = await vehicleWriteOnlyRepository.Add(new Vehicle( vehicle.Name,vehicle.Id, vehicle.BrandId, vehicle.ModelsId,vehicle.Value,vehicle.YearModel,vehicle.Fuel));

            return new VehiclesResult(IdResult, vehicle.Name, IdResult != -1 ? "OK" : "NOK");
        }

        

    }
}

﻿using labor.Domain.BaseEntity;
using labor.Domain.Validate;
using System;
using System.Collections.Generic;
using System.Text;

namespace labor.Domain.VehiclesE
{
    public class Vehicle : Entity
    {
        public string   Name  { get; private set; }
        public int     BrandId { get; private set; }
        public int     ModelsId  { get; private set; }
        public decimal  Value { get; private set; }
        public DateTime YearModel { get; set; }
        public int      Fuel { get; set; }

        public Vehicle(string name,int Id, int brandId, int modelsId, decimal value, DateTime yearModel,int fuel)
        {
            Name = name ;
            this.Id = Id;
            BrandId = brandId;
            ModelsId = modelsId;
            Value = value;
            YearModel = yearModel;
            Fuel = fuel;
        }

        public override bool IsValidate()
        {
            var Result = new VehiclesValidate().Validate(this);
            return Result.IsValid;
        }
    }
}

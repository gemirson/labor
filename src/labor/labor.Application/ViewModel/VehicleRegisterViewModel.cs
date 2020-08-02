﻿using FluentValidation.Results;
using labor.Application.Helper;
using labor.Application.Mediatr.Commands;

namespace labor.Application.ViewModel
{
    public class VehicleRegisterViewModel : ICommand<ResultE>
    {
        public int     Id { get; set; }
        public string  Name { get; set; }
        public int     IdBrand { get; set; }
        public int     IdModel { get; set; }
        public decimal Value { get; private set; }
        public int     YearModel { get; set; }
        public int     Fuel { get; set; }
      
    }
}

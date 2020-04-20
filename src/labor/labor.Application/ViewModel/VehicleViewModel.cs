using FluentValidation.Results;

namespace labor.Application.ViewModel
{
    public class VehicleViewModel
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

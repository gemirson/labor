using labor.Domain.VehiclesE;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace labor.Domain.Specifications
{
    public sealed class VehicleWithBrandSpecification: BaseSpecification<Vehicle>
    {
        public VehicleWithBrandSpecification(int? idBrand)
        : base(Where(idBrand))
        {

            AddInclude(x => x.BrandId);


        }

        private static Expression<Func<Vehicle, bool>> Where(int? idBrand)
        {

            return x => idBrand == null || x.BrandId == idBrand;

        }
    }
}

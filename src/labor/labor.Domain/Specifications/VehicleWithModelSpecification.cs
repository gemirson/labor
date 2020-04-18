using labor.Domain.VehiclesE;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace labor.Domain.Specifications
{
    public sealed class VehicleWithModelSpecification : BaseSpecification<Vehicle>
    {
        public VehicleWithModelSpecification(int? idModel)
        : base(Where(idModel))
        {

            AddInclude(x => x.BrandId);


        }

        private static Expression<Func<Vehicle, bool>> Where(int? idModel)
        {
            return x => idModel == null || x.BrandId == idModel;

        }
    }
}

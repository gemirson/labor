using labor.Domain.ModelsE;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace labor.Domain.Specifications
{
    public sealed class ModelWithBrandSpecification : BaseSpecification<Model>
    {
        public ModelWithBrandSpecification(int? idBrand)
         : base(Where(idBrand))
        {
             
           AddInclude(x => x.BrandId);

          
        }

        private static Expression<Func<Model, bool>> Where(int? idBrand)
        {
         
            return x => idBrand == null || x.BrandId == idBrand;
            
        }
    }
   
}

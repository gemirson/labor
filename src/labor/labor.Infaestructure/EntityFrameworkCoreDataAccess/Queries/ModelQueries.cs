using labor.Application.Queries.Models;
using labor.Domain.ModelsE;
using labor.Domain.Specifications;
using labor.Infaestructure.EntityFrameworkCoreDataAccess.Context;
using labor.Infaestructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor.Infaestructure.EntityFrameworkCoreDataAccess.Queries
{
    public class ModelQueries : IModelQueries
    {

        private readonly DBContext context;

        public async Task<Model> Get(int Id)
        {
            return await context.Models.FindAsync(Id);
        }

        public async Task<IReadOnlyList<Model>> GetModelByBrand(ISpecification<Model> specification)
        {
            return await ApplySpecification(specification).ToListAsync().ConfigureAwait(true);
        }
        
        private IQueryable<Model> ApplySpecification(ISpecification<Model> spec)
        {
            return SpecificationEvaluator<Model>.GetQuery(context.Set<Model>().AsQueryable(), spec);
        }

    }
}

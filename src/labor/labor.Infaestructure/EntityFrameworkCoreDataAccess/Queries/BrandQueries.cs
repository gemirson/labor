using labor.Application.Queries.Brands;
using labor.Domain.BrandsE;
using labor.Infaestructure.EntityFrameworkCoreDataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace labor.Infaestructure.EntityFrameworkCoreDataAccess.Queries
{
    public class BrandQueries: IBrandQueries
    {
        private readonly DBContext context;

        public BrandQueries(DBContext context)
        {
            this.context = context;
        }

        public async Task<Brand> Get(int Id)
        {
           return await context.Brands.FindAsync(Id);
        }

        public async  Task<IReadOnlyList<Brand>> GetAll()
        {
            return   await context.Brands.ToListAsync().ConfigureAwait(true);
        }
    }
}

using labor.Application.Repositories;
using labor.Domain.BrandsE;
using labor.Infaestructure.EntityFrameworkCoreDataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace labor.Infaestructure.EntityFrameworkCoreDataAccess.Repositories
{

    public class BrandRepository : IBrandsReadOnlyRepository, IBrandsWriteOnlyRepository
    {

        private readonly DBContext context;

        BrandRepository(DBContext _context)
        {
            this.context = _context;
        }
        
        public async Task<int> Add(Brand models)
        {
            var result = await  context.AddAsync(models);
            await context.SaveChangesAsync().ConfigureAwait(true);
            return result.Entity.Id;
        }

        public async Task<int> Delete(int IdBrand)
        {
            string query_string_delete = @"DELETE FROM Brand WHERE Id = @Id";
                    
            var id = new SqlParameter("@Id", IdBrand);

            int affectedRows = await context.Database.ExecuteSqlRawAsync(
                query_string_delete, id).ConfigureAwait(true);

            return affectedRows;
        }

        public async Task<Brand> Get(int id)
        {
            return  await context.Brands.FindAsync(id);
        }

        public async Task<IReadOnlyList<Brand>> GetAll()
        {
            return await context.Brands.ToListAsync().ConfigureAwait(true);
            
        }

        public async  Task<int> Update(Brand models)
        {
            var result = await context.AddAsync(models);
                         await context.SaveChangesAsync().ConfigureAwait(true);
;            return result.Entity.Id;
        }
    }
}

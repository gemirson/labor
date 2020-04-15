using labor.Application.Repositories;
using labor.Application.Specifications;
using labor.Domain.ModelsE;
using labor.Infaestructure.EntityFrameworkCoreDataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace labor.Infaestructure.EntityFrameworkCoreDataAccess.Repositories
{
    public class ModelRepository : IModelsReadOnlyRepository, IModelWriteOnlyRepository
    {

        private readonly DBContext context;

        public ModelRepository(DBContext _context)
        {
            this.context = _context;
        }
        public async Task<int> Add(Model models)
        {
            var result = await context.AddAsync(models);
            await context.SaveChangesAsync().ConfigureAwait(true);
            return result.Entity.Id;
        }

        public async Task Delete(Model models)
        {
            string query_string_delete =
                      @"DELETE FROM Model WHERE Id = @Id";
                      var id = new SqlParameter("@Id", models.Id);

            int affectedRows = await context.Database.ExecuteSqlRawAsync(
               query_string_delete, id).ConfigureAwait(true);
        }

        public Task<Model> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Model>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Model>> GetBy(ISpecification<Model> specification)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Model models)
        {
            var result = await context.AddAsync(models);
            await context.SaveChangesAsync().ConfigureAwait(true);
            
        }
    }
}

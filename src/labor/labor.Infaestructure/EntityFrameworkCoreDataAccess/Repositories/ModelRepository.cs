using labor.Application.Repositories;
using labor.Domain.ModelsE;
using labor.Domain.Specifications;
using labor.Infaestructure.EntityFrameworkCoreDataAccess.Context;
using labor.Infaestructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace labor.Infaestructure.EntityFrameworkCoreDataAccess.Repositories
{
    public class ModelRepository : IModelsReadOnlyRepository, IModelWriteOnlyRepository, IDisposable
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

        public async Task<int> Delete(int IdModel)
        {

            string query_string_delete =
                      @"DELETE FROM Model WHERE Id = @Id";
                      var id = new SqlParameter("@Id", IdModel);

            int affectedRows = await context.Database.ExecuteSqlRawAsync(
               query_string_delete, id).ConfigureAwait(true);

            return affectedRows;
        }

        public async Task<Model> Get(int id)
        {
            return await context.Models.FindAsync(id);
        }

        public async Task<IReadOnlyList<Model>> GetAll()
        {
            return await context.Models.ToListAsync().ConfigureAwait(true);
        }

        public async  Task<IReadOnlyList<Model>> GetByBrand(ISpecification<Model> specification)
        {
            return await ApplySpecification(specification).ToListAsync().ConfigureAwait(true);
        }

        public async Task<int> Update(Model models)
        {
            context.Entry(models).State = EntityState.Modified;
            await context.SaveChangesAsync().ConfigureAwait(true);
            return context.Entry(models).Entity.Id;
        }


        private IQueryable<Model> ApplySpecification(ISpecification<Model> spec)
        {
            return SpecificationEvaluator<Model>.GetQuery(context.Set<Model>().AsQueryable(), spec);
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

      
    }
}

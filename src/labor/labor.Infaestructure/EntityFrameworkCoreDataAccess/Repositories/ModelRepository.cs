using labor.Application.Repositories;
using labor.Application.Specifications;
using labor.Domain.ModelsE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Infaestructure.EntityFrameworkCoreDataAccess.Repositories
{
    public class ModelRepository : IModelsReadOnlyRepository, IModelWriteOnlyRepository
    {
        public Task<int> Add(Model models)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Model models)
        {
            throw new NotImplementedException();
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

        public Task Update(Model models)
        {
            throw new NotImplementedException();
        }
    }
}

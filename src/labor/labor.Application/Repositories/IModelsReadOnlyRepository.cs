using labor.Application.Specification;
using labor.Application.Specifications;
using labor.Domain.ModelsE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Repositories
{
    public interface IModelsReadOnlyRepository
    {
        Task<Model> Get(int id);
        Task<IReadOnlyList<Model>> GetBy(ISpecification<Model> specification);
        Task<IReadOnlyList<Model>> GetAll();
    }
}

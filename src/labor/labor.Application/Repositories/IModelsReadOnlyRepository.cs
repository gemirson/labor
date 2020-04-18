using labor.Domain.ModelsE;
using labor.Domain.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace labor.Application.Repositories
{
    public interface IModelsReadOnlyRepository
    {
        Task<Model> Get(int id);
        Task<IReadOnlyList<Model>> GetByBrand(ISpecification<Model> specification);
        Task<IReadOnlyList<Model>> GetAll();
    }
}

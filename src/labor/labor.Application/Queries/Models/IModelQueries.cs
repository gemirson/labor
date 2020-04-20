using labor.Domain.ModelsE;
using labor.Domain.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace labor.Application.Queries.Models
{
    public interface IModelQueries
    {
        Task<Model> Get(int Id);
        Task<IReadOnlyList<Model>> GetModelByBrand(ISpecification<Model> specification);
    }
}

using labor.Domain.ModelsE;
using System.Threading.Tasks;

namespace labor.Application.Repositories
{
    public interface IModelWriteOnlyRepository
    {
        Task<int> Add(Model  models);
        Task Update(Model models);
        Task Delete(Model  models);
    }
}

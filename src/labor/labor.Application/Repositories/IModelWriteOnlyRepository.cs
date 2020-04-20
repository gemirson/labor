using labor.Domain.ModelsE;
using System.Threading.Tasks;

namespace labor.Application.Repositories
{
    public interface IModelWriteOnlyRepository
    {
        Task<int> Add(Model  models);
        Task<int> Update(Model models);
        Task<int> Delete(int IdModel);
    }
}

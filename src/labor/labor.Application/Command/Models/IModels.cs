using labor.Application.Command.Models;
using System.Threading.Tasks;
using labor.Domain.ModelsE;

namespace labor.Application.Command.Brands
{
    interface IModel
    {
        Task<ModelResult> ModelHandler(Model models);
    }
}

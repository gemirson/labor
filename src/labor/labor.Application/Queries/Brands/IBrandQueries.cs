using labor.Application.Command.Brands.Result;
using System.Threading.Tasks;

namespace labor.Application.Queries.Brands
{
    interface IBrandQueries
    {
        Task<BrandResult> Get(int Id);
    }
}

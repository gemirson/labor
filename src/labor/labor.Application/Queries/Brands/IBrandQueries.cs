using labor.Domain.BrandsE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace labor.Application.Queries.Brands
{
    public interface IBrandQueries
    {
        Task<Brand> Get(int Id);
        Task<IReadOnlyList<Brand>> GetAll();
    }
}

using labor.Application.Command.Brands;
using labor.Domain.BrandsE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Repositories
{
    public interface IBrandsReadOnlyRepository
    {
        Task<Brand> Get(int id);
        Task<IReadOnlyList<Brand>> GetAll();
    }
}

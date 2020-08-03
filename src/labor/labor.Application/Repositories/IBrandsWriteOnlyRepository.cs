using labor.Application.Command.Brands;
using labor.Domain.BrandsE;
using System;
using System.Threading.Tasks;

namespace labor.Application.Repositories
{
    public interface IBrandsWriteOnlyRepository
    {
        Task<int> Add(Brand models);
        Task<int> Edit(Brand models);
        Task<int> Delete(int IdBrand);
    }
}

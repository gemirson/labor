using labor.Domain.BrandsE;
using System;
using System.Threading.Tasks;

namespace labor.Application.Command.Brands.Delete
{
    public interface IBrandDelete
    {
        Task<int> Handler(int IdBrand);
    }
}

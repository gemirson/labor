using labor.Application.Command.Brands.Result;
using labor.Domain.BrandsE;
using System;
using System.Threading.Tasks;

namespace labor.Application.Command.Brands.Register
{
    interface IBrandRegister
    {
        Task<BrandResult> Handler(Brand brands);
    }
}

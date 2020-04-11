using labor.Application.Command.Brands.Result;
using labor.Domain.BrandsE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Command.Brands.Changess
{
    interface IBrandChange
    {
       Task<BrandResult> Handler(Brand brand);
    }
}

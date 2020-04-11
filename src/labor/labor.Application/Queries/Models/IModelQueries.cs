using labor.Application.Command.Brands.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Queries.Models
{
    interface IModelQueries
    {
        Task<BrandResult> Get(int Id);
    }
}

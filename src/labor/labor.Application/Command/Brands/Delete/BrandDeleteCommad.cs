using labor.Application.Repositories;
using labor.Domain.BrandsE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Command.Brands.Delete
{
    public class BrandDeleteCommand : IBrandDelete
    {
        private readonly IBrandsWriteOnlyRepository brandsWriteOnlyRepository;

        BrandDeleteCommand(IBrandsWriteOnlyRepository _brandsWriteOnlyRepository)
        {
            brandsWriteOnlyRepository = _brandsWriteOnlyRepository;
        }
       
        public async Task<int> Handler(int IdBrand)
        {
            var IdResult = await brandsWriteOnlyRepository.Delete(IdBrand);

            return IdResult;
        }
    }
}

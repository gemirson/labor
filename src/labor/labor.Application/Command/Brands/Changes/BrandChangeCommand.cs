using labor.Application.Command.Brands.Changess;
using labor.Application.Command.Brands.Result;
using labor.Application.Repositories;
using labor.Domain.BrandsE;
using System;
using System.Threading.Tasks;

namespace labor.Application.Command.Brands.Changes
{
    public class BrandChangeCommand : IBrandChange
    {

        private readonly IBrandsWriteOnlyRepository brandsWriteOnlyRepository;

        BrandChangeCommand(IBrandsWriteOnlyRepository brandsWriteOnlyRepository)
        {
            this.brandsWriteOnlyRepository = brandsWriteOnlyRepository ?? throw new ArgumentNullException(nameof(brandsWriteOnlyRepository));
        }

        public async Task<BrandResult> Handler(Brand brand)
        {
            var IdResult = await brandsWriteOnlyRepository.Update(brand);

            return new BrandResult(IdResult, brand.Name, IdResult != -1 ? "OK" : "NOK");
        }
    }
}

using labor.Application.Command.Brands.Changess;
using labor.Application.Command.Brands.Result;
using labor.Application.Repositories;
using labor.Application.ViewModel;
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

        public async Task<BrandResult> Handler(BrandViewModel brand)
        {
            if (brand.ValidationResult.IsValid)
            {
                var IdResult = await brandsWriteOnlyRepository.Update(new Brand(brand.Id, brand.Name));

                return new BrandResult(IdResult, brand.Name, IdResult != -1 ? "OK" : "NOK");
            }

            return new BrandResult(-1, brand.Name, "NOK");
        }
    }
}

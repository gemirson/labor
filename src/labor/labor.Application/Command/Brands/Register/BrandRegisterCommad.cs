using labor.Application.Command.Brands.Result;
using labor.Application.Repositories;
using labor.Application.ViewModel;
using labor.Domain.BrandsE;
using System.Threading.Tasks;

namespace labor.Application.Command.Brands.Register
{
    public class BrandCommand : IBrandRegister
    {
        private readonly IBrandsWriteOnlyRepository brandsWriteOnlyRepository;

        BrandCommand(IBrandsWriteOnlyRepository _brandsWriteOnlyRepository)
        {
            brandsWriteOnlyRepository = _brandsWriteOnlyRepository;
        }
                 
       
        public async Task<BrandResult> Handler(BrandViewModel brands)
        {
           
            if (brands.ValidationResult.IsValid) 
            {
                var IdResult = await brandsWriteOnlyRepository.Add(new Brand(brands.Id,brands.Name));
                return new BrandResult(IdResult, brands.Name, IdResult != -1 ? "OK" : "NOK");

            }

            return new BrandResult(-1, brands.Name,"NOK");
        }
    }
}

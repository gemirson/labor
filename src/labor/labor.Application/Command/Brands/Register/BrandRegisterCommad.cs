using labor.Application.Command.Brands.Result;
using labor.Application.Repositories;
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
                 
       
        public async Task<BrandResult> Handler(Brand brands)
        {
            var IdResult = await brandsWriteOnlyRepository.Add(brands);
            return new BrandResult(IdResult, brands.Name,IdResult!=-1 ? "OK":"NOK");
        }
    }
}

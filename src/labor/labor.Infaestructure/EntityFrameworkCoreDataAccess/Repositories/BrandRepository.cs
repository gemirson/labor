using labor.Application.Repositories;
using labor.Domain.BrandsE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace labor.Infaestructure.EntityFrameworkCoreDataAccess.Repositories
{

    public class BrandRepository : IBrandsReadOnlyRepository, IBrandsWriteOnlyRepository
    {
        public Task<int> Add(Brand models)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int IdBrand)
        {
            throw new System.NotImplementedException();
        }

        public Task<Brand> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Brand>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Brand models)
        {
            throw new System.NotImplementedException();
        }
    }
}

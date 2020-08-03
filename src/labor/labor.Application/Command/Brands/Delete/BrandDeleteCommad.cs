using labor.Application.Helper;
using labor.Application.Repositories;
using labor.Application.ViewModel;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace labor.Application.Command.Brands.Delete
{
    public class BrandDeleteCommand : IRequestHandler<BrandDeleteViewModel, ResultE>
    {
        private readonly IBrandsWriteOnlyRepository brandsWriteOnlyRepository;

        BrandDeleteCommand(IBrandsWriteOnlyRepository _brandsWriteOnlyRepository)
        {
            brandsWriteOnlyRepository = _brandsWriteOnlyRepository;
        }

        public async  Task<ResultE> Handle(BrandDeleteViewModel request, CancellationToken cancellationToken)
        {
            var IdResult = await brandsWriteOnlyRepository.Delete(request.Id);
             return new ResultE(new Guid(), request.Id.ToString(), IdResult !=-1 ? "DELETED" : "NOT  DELETED");
            
        }

      
    }
}

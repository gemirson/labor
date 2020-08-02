using labor.Application.Helper;
using labor.Application.Repositories;
using labor.Application.ViewModel;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace labor.Application.Command.Models.Delete
{
    public class ModelDeleteCommand : IRequestHandler<ModelDeleteViewModel, ResultE>
    {
        private readonly IModelWriteOnlyRepository modelWriteOnlyRepository;

        public ModelDeleteCommand(IModelWriteOnlyRepository modelWriteOnlyRepository)
        {
            this.modelWriteOnlyRepository = modelWriteOnlyRepository;
        }

        public async Task<ResultE> Handle(ModelDeleteViewModel request, CancellationToken cancellationToken)
        {
            var IdResult = await modelWriteOnlyRepository.Delete(request.Id);
            return new ResultE(new Guid(),request.Id.ToString(),IdResult !=-1 ? "MODEL DELETED WITH SUCESS":"MODEL NOT DELETED");
        }

         
        }
    }
}

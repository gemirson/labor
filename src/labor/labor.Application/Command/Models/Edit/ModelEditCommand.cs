using AutoMapper;
using labor.Application.Helper;
using labor.Application.Repositories;
using labor.Application.ViewModel;
using labor.Domain.ModelsE;
using labor.Domain.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace labor.Application.Command.Models.Changes
{
    public class ModelEditCommand : IRequestHandler<ModelEditViewModel, ResultE>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IModelWriteOnlyRepository modelWriteOnlyRepository;

        public ModelEditCommand(IMapper mapper, NotificationContext notificationContext, IModelWriteOnlyRepository modelWriteOnlyRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            this.modelWriteOnlyRepository = modelWriteOnlyRepository;
        }

        public async Task<ResultE> Handle(ModelEditViewModel request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ModelEditViewModel, Model>(request);

            if (model.ValidationResult.IsValid)
            {
                _notificationContext.AddNotifications(model.ValidationResult);
                return new ResultE(new System.Guid(), model.Name, "NOT EDITED MODEL");

            }

            var IdResult = await modelWriteOnlyRepository.Edit(new Model(model.Id, model.Name, model.BrandId));

            return new ResultE(new System.Guid() , model.Name, IdResult != -1 ? "EDITED WITH SUCESS" : "NOT EDITED MODEL");
        }

        
    }
}

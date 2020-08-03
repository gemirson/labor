using AutoMapper;
using labor.Application.Helper;
using labor.Application.Repositories;
using labor.Application.ViewModel;
using labor.Domain.ModelsE;
using labor.Domain.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace labor.Application.Command.Models.Register
{
    public class ModelRegisterCommand : IRequestHandler<ModelRegisterViewModel, ResultE>
    {

        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IModelWriteOnlyRepository modelWriteOnlyRepository;

        public ModelRegisterCommand(IMapper mapper, NotificationContext notificationContext, IModelWriteOnlyRepository modelWriteOnlyRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            this.modelWriteOnlyRepository = modelWriteOnlyRepository;
        }

        public async Task<ResultE> Handle(ModelRegisterViewModel request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ModelRegisterViewModel, Model>(request);

            if (model.ValidationResult.IsValid)
            {
                _notificationContext.AddNotifications(model.ValidationResult);
                return new ResultE(new Guid(), model.Name, "NOT CREATED");

            }

            var IdResult = await modelWriteOnlyRepository.Add(new Model(model.Id, model.Name, model.BrandId));

            return new ResultE(new Guid(), model.Name, IdResult != -1 ? "CREATED WITH SUCESS" : "NOT CREATED");
        }

      
    }
}

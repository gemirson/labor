using AutoMapper;
using labor.Application.Command.Models.Result;
using labor.Application.Repositories;
using labor.Application.ViewModel;
using labor.Domain.ModelsE;
using labor.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Command.Models.Changes
{
    public class ModelChangeCommand : IModelChange
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IModelWriteOnlyRepository modelWriteOnlyRepository;

        public ModelChangeCommand(IMapper mapper, NotificationContext notificationContext, IModelWriteOnlyRepository modelWriteOnlyRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            this.modelWriteOnlyRepository = modelWriteOnlyRepository;
        }

        public async Task<ModelResult> Handler(ModelViewModel modelViewModel, NotificationContext notificationContext)
        {
            var model = _mapper.Map<ModelViewModel, Model>(modelViewModel);

            if (model.ValidationResult.IsValid)
            {
                _notificationContext.AddNotifications(model.ValidationResult);
                return new ModelResult(-1, model.Name, "NOK");

            }

            var IdResult = await modelWriteOnlyRepository.Update(new Model(model.Id, model.Name, model.BrandId));

            return new ModelResult(IdResult, model.Name, IdResult != -1 ? "OK" : "NOK");
        }
    }
}

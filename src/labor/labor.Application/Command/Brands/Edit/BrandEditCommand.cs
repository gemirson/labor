using AutoMapper;
using labor.Application.Helper;
using labor.Application.Repositories;
using labor.Application.ViewModel;
using labor.Domain.BrandsE;
using labor.Domain.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace labor.Application.Command.Brands.Changes
{
    public class BrandEditCommand : IRequestHandler<BrandEditViewModel, ResultE>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IBrandsWriteOnlyRepository brandsWriteOnlyRepository;

        public BrandEditCommand(IMapper mapper, NotificationContext notificationContext, IBrandsWriteOnlyRepository brandsWriteOnlyRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            this.brandsWriteOnlyRepository = brandsWriteOnlyRepository;
        }

        public async  Task<ResultE> Handle(BrandEditViewModel request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<BrandEditViewModel, Brand>(request);

            if (brand.ValidationResult.IsValid)
            {
                _notificationContext.AddNotifications(brand.ValidationResult);

                return new ResultE( new System.Guid(), brand.Name, "NOT  EDITED");

            }

            var IdResult = await brandsWriteOnlyRepository.Update(new Brand(brand.Id, brand.Name));

            return new ResultE(new System.Guid(), brand.Name, IdResult != -1 ? "EDITED" : "NOT EDITED");
        }

       
    }
}

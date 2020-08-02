using AutoMapper;
using labor.Application.Command.Brands.Result;
using labor.Application.Repositories;
using labor.Application.ViewModel;
using labor.Domain.BrandsE;
using labor.Domain.Notifications;
using labor.Application.Helper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace labor.Application.Command.Brands.Register
{
    public class BrandRegisterCommand : IRequestHandler<BrandRegisterViewModel,ResultE>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IBrandsWriteOnlyRepository brandsWriteOnlyRepository;

        public BrandRegisterCommand(IMapper mapper, NotificationContext notificationContext, IBrandsWriteOnlyRepository brandsWriteOnlyRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            this.brandsWriteOnlyRepository = brandsWriteOnlyRepository;
        }

        public async Task<ResultE> Handle(BrandRegisterViewModel request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<BrandRegisterViewModel, Brand>(request);
           
            if (brand.ValidationResult.IsValid)
            {
                _notificationContext.AddNotifications(brand.ValidationResult);

                return  new ResultE(new Guid(),brand.Name,"NOT CREATED");

            }

            var IdResult = await brandsWriteOnlyRepository.Add(new Brand(brand.Id, brand.Name));
            return new ResultE(new Guid(), brand.Name, IdResult !=-1 ? "CREATED" : "NOT CREATED");
        }

       
    }
}

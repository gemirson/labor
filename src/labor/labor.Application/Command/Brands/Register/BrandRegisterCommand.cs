using AutoMapper;
using labor.Application.Command.Brands.Result;
using labor.Application.Repositories;
using labor.Application.ViewModel;
using labor.Domain.BrandsE;
using labor.Domain.Notifications;
using System.Threading.Tasks;

namespace labor.Application.Command.Brands.Register
{
    public class BrandCommand : IBrandRegister
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IBrandsWriteOnlyRepository brandsWriteOnlyRepository;

        public BrandCommand(IMapper mapper, NotificationContext notificationContext, IBrandsWriteOnlyRepository brandsWriteOnlyRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            this.brandsWriteOnlyRepository = brandsWriteOnlyRepository;
        }

        public async Task<BrandResult> Handler(BrandViewModel brandViewModel, NotificationContext notificationContext)
        {
            var brand = _mapper.Map<BrandViewModel, Brand>(brandViewModel);

            if (brand.ValidationResult.IsValid)
            {
                _notificationContext.AddNotifications(brand.ValidationResult);
                return new BrandResult(-1, brand.Name, "NOK");

            }

            var IdResult = await brandsWriteOnlyRepository.Add(new Brand(brand.Id, brand.Name));
            return new BrandResult(IdResult, brand.Name, IdResult != -1 ? "OK" : "NOK");
           
        }
    }
}

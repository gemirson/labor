using AutoMapper;
using labor.Application.Command.Brands.Result;
using labor.Application.ViewModel;
using labor.Domain.BrandsE;
using labor.Domain.Notifications;
using System;
using System.Threading.Tasks;

namespace labor.Application.Command.Brands.Register
{
    public interface IBrandRegister
    {
        Task<BrandResult> Handler(BrandViewModel brandViewModel, NotificationContext notificationContext);
    }
}

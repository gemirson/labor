using AutoMapper;
using labor.Application.Command.Brands.Result;
using labor.Application.ViewModel;
using labor.Domain.Notifications;
using System.Threading.Tasks;

namespace labor.Application.Command.Brands.Changess
{
    interface IBrandChange
    {
       Task<BrandResult> Handler(BrandViewModel brandViewModel, NotificationContext notificationContext);
    }
}

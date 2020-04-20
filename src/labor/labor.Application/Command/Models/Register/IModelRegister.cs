using labor.Application.Command.Models.Result;
using labor.Application.ViewModel;
using labor.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Command.Models.Register
{
    public interface IModelRegister
    {
        Task<ModelResult> Handler(ModelViewModel modelViewModel, NotificationContext notificationContext);
    }
}

using labor.Application.Command.Models.Result;
using labor.Application.ViewModel;
using labor.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Command.Models.Changes
{
    interface IModelChange
    {
        Task<ModelResult> Handler(ModelViewModel modelViewModel, NotificationContext notificationContext);
    }
}

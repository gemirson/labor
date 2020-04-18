using System;
using System.Collections.Generic;
using System.Text;

namespace labor.Domain.Interface.Notification
{
    public interface IDescription
    {
        string Message { get; }

        string ToString();
    }
}

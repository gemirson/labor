using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Command.Models.Delete
{
    interface IModelDelete
    {
        Task<int> Handler(int IdModel);
    }
}

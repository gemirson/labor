using System;
using System.Collections.Generic;
using System.Text;

namespace labor.Domain.Interface.Error
{
    public interface ILevel
    {  
        string Description { get; }
        string ToString();
    }
}

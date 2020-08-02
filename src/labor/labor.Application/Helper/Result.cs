using System;
using System.Collections.Generic;
using System.Text;

namespace labor.Application.Helper
{
    public struct ResultE
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Status { get; private set; }

        public ResultE(Guid id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
    }
    


  

     
}

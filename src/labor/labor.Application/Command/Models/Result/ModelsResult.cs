using System;
using System.Collections.Generic;
using System.Text;

namespace labor.Application.Command.Models.Result
{
    public class ModelResult
    {

        public int Id { get;private set; }
        public  string Name { get;private set; }
        public  string Status { get; private set; }

        public ModelResult(int id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
    }
}

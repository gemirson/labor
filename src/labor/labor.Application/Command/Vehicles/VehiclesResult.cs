using System;
using System.Collections.Generic;
using System.Text;

namespace labor.Application.Command.Models
{
    public class VehiclesResult
    {

        public int Id { get;private set; }
        public  string Name { get;private set; }

        public VehiclesResult(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

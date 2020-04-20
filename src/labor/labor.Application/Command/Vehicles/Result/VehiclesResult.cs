using System;
using System.Collections.Generic;
using System.Text;

namespace labor.Application.Command.Vehicles.Result
{
    public class VehiclesResult
    {

        public int Id { get;private set; }
        public  string Name { get;private set; }

        public string Status { get; private set; }

        public VehiclesResult(int id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
    }
}

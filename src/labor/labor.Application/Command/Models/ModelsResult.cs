using System;
using System.Collections.Generic;
using System.Text;

namespace labor.Application.Command.Models
{
    public class ModelResult
    {

        public int Id { get;private set; }
        public  string Name { get;private set; }

        public ModelResult(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

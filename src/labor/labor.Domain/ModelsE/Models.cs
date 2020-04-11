using labor.Domain.BaseEntity;
using labor.Domain.Validate;
using System;

namespace labor.Domain.ModelsE
{
    public class Model : Entity
    {        
        public string Name { get; private set; }

        public Model(int Id, string name)
        {
            this.Id = Id;
            this.Name = name;
        }
        public override bool IsValidate()
        {
            var Result = new ModelsValidate().Validate(this);
            return Result.IsValid;
        }
    }
}

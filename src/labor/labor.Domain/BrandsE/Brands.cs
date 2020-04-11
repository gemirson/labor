using System;
using labor.Domain.BaseEntity;
using labor.Domain.Validate;

namespace labor.Domain.BrandsE
{
    public class Brand : Entity
    {
        public string Name { get; private set; }
        
        public Brand(int Id,string name)
        {
            this.Id = Id;
            this.Name = name;
        }
        
        public override bool IsValidate()
        {
            var Result = new BrandsValidate().Validate(this);
            return Result.IsValid;
        }
    }
}

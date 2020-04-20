using System;
using FluentValidation;
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
            Validate(this, new BrandsValidate());
        }
        
        public override bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            var Result = new BrandsValidate().Validate(this);
            return Result.IsValid;
        }
    }
}

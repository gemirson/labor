using FluentValidation;
using labor.Domain.BaseEntity;
using labor.Domain.Validate;
using System;

namespace labor.Domain.ModelsE
{
    public class Model : Entity
    {        
        public string Name { get; private set; }
        public int BrandId { get; private set; }

        public Model(int Id, string name,int  IdBrand)
        {
            this.Id = Id;
            this.Name = name;
            this.BrandId = IdBrand;
            Validate(this, new ModelsValidate());
        }
        
        public override bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            var Result = new ModelsValidate().Validate(this);
            return Result.IsValid;
        }
    }
}

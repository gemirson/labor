using FluentValidation.Results;

namespace labor.Application.ViewModel
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public BrandViewModel()
        {
            ValidationResult = new ValidationResult();
        }
    }
}

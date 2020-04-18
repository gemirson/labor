﻿using FluentValidation.Results;

namespace labor.Application.ViewModel
{
    public class ModelViewModel
    {
        public int    Id { get; set; }
        public string Name { get; set; }
        public int    IdBrand { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public ModelViewModel()
        {
            ValidationResult = new ValidationResult();
        }
    }
}

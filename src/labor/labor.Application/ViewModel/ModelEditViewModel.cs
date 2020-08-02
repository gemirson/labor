using FluentValidation.Results;
using labor.Application.Helper;
using labor.Application.Mediatr.Commands;

namespace labor.Application.ViewModel
{
    public class ModelEditViewModel: ICommand<ResultE>
    {
        public int    Id { get; set; }
        public string Name { get; set; }
        public int    IdBrand { get; set; }
       
    }
}

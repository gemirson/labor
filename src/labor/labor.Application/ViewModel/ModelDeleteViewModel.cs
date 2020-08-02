using FluentValidation.Results;
using labor.Application.Helper;
using labor.Application.Mediatr.Commands;

namespace labor.Application.ViewModel
{
    public class ModelDeleteViewModel: ICommand<ResultE>
    {
        public int    Id { get; set; }
       
       
    }
}

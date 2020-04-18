using labor.Application.Command.Brands.Result;
using labor.Application.ViewModel;
using System.Threading.Tasks;

namespace labor.Application.Command.Brands.Changess
{
    interface IBrandChange
    {
       Task<BrandResult> Handler(BrandViewModel brand);
    }
}

using labor.Application.Command.Brands;
using labor.Application.Repositories;
using labor.Domain.BrandsE;
using labor.Domain.ModelsE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Command.Models
{
    public class ModelsCommand : IModel
    {
        private readonly IModelWriteOnlyRepository modelWriteOnlyRepository;

        ModelsCommand(IModelWriteOnlyRepository _modelWriteOnlyRepository)
        {
            modelWriteOnlyRepository = _modelWriteOnlyRepository;
        }
                
       
        public async Task<ModelResult> ModelHandler(Model model)
        {           
            var IdResult  =  await modelWriteOnlyRepository.Add(model);
            return new ModelResult(IdResult,model.Name);
        }
    }
}

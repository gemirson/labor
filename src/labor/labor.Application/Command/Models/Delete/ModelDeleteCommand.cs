using labor.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labor.Application.Command.Models.Delete
{
    public class ModelDeleteCommand : IModelDelete
    {
        private readonly IModelWriteOnlyRepository modelWriteOnlyRepository;

        public ModelDeleteCommand(IModelWriteOnlyRepository modelWriteOnlyRepository)
        {
            this.modelWriteOnlyRepository = modelWriteOnlyRepository;
        }

        public async  Task<int> Handler(int IdModel)
        {
            var IdResult = await modelWriteOnlyRepository.Delete(IdModel);
            return IdResult;
        }
    }
}

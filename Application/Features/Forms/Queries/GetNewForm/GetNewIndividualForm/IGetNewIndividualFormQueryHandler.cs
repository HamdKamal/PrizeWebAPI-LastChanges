using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.GetNewForm.GetNewIndividualForm
{
    public interface IGetNewIndividualFormQueryHandler
    {  
        public Task<GetNewIndividualFormQueryResult> HandleAsync(GetNewIndividualFormQueryModel getNewFormQueryModel);
    }
}

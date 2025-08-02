using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.GetNewForm.GetNewDepartmentForm
{
    public interface IGetNewDepartmentFormQueryHandler
    {
        public Task<GetNewDepartmentFormQueryResult> HandleAsync(GetNewDepartmentFormQueryModel getNewFormQueryModel);
    }
}

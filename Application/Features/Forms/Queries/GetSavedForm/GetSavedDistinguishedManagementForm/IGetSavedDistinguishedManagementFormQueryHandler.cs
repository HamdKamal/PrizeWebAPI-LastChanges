using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.GetSavedForm.GetSavedDistinguishedManagementForm
{
    public interface IGetSavedDistinguishedManagementFormQueryHandler
    {
        public Task<GetSavedDistinguishedManagementFormQueryResult> HandleAsync(int submissionId);
    }
}

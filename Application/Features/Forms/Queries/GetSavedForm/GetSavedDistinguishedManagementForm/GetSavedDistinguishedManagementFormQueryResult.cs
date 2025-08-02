using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.GetSavedForm.GetSavedDistinguishedManagementForm
{
    public class GetSavedDistinguishedManagementFormQueryResult
    {
        public List<Dictionary<int,FormSubmission>> draftForm { get; set; }
        public List<Dictionary<string, object>> initialFormValues { get; set; }
    }
}

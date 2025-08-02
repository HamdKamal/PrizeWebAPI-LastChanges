using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.GetSavedForm.GetSavedCreativityForm
{
    public class GetSavedCreativityFormQueryResult
    {
        public List<Dictionary<int,FormSubmission>> draftForm { get; set; }
        public List<Dictionary<int, object>> initialFormValues { get; set; }
    }
}

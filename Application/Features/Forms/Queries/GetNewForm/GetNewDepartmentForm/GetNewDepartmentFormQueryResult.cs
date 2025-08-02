using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.GetNewForm.GetNewDepartmentForm
{
    public class GetNewDepartmentFormQueryResult
    {
        public List<FormSection> formSections { get; set; }
        public List<FormSubSection> formSubSections { get; set; }
        public List<Question> questions { get; set; }
    }
}

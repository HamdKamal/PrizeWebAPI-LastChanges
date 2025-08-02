using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.GetSavedForm
{
    public class GetSavedFormQueryResult
    {
        public FormSubmission formSubmission { get; set; }
        public List<SubmittedAnswer>? submittedAnswers { get; set; }
        public List<SubmittedAttachment>? submittedAttachments { get; set; }
        public List<Participant>? particpants { get; set; }
    }
}

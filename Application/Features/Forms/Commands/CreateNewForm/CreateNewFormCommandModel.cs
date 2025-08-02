using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Commands.CreateNewForm
{
    public class CreateNewFormCommandModel
    {
        public FormSubmission submission { get; set; }
        public List<SubmittedAnswer> answers { get; set; }
        public List<SubmittedAttachment> attachments { get; set; }
        public List<Participant>? participants{ get; set; }
    }
}

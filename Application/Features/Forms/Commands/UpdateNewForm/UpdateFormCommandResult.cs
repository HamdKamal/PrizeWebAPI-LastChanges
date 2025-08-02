using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Commands.UpdateNewForm
{
    public class UpdateFormCommandResult
    {
        public FormSubmission submission { get; set; }
        public List<SubmittedAnswer> answers { get; set; }
        public List<SubmittedAttachment> attachments { get; set; }
        public List<Participant>? particpants { get; set; }
    }
}

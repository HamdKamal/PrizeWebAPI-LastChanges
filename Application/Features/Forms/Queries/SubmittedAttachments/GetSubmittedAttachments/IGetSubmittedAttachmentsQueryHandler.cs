using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.GetSavedForm
{
    public interface IGetSubmittedAttachmentsQueryHandler
    {
        public Task<SubmittedAttachment> HandleAsync(int id);
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.Statuses
{
    public interface IGetStatusesQueryHandler
    {
        public Task<List<Status>> HandleGetAllStatusesAsync();
    }
}

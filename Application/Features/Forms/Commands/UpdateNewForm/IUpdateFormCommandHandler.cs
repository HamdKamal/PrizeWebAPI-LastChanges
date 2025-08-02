using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Commands.UpdateNewForm
{
    public interface IUpdateFormCommandHandler
    {
        public Task<UpdateFormCommandResult> HandleAsync(UpdateFormCommandModel commandModel);
    }
}

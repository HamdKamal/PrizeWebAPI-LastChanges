using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Commands.CreateNewForm
{
    public interface ICreateNewFormCommandHandler
    {
        public Task<CreateNewFormCommandResult> HandleAsync(CreateNewFormCommandModel commandModel);
    }
}

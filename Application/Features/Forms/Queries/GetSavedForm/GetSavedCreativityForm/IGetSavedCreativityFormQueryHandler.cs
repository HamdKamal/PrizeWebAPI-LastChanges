using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.GetSavedForm.GetSavedCreativityForm
{
    public interface IGetSavedCreativityFormQueryHandler
    {
        public Task<GetSavedCreativityFormQueryResult> HandleAsync(GetSavedCreativityFormQueryModel getSavedFormQueryModel);
    }
}

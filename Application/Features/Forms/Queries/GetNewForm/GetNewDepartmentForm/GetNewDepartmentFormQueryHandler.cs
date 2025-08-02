using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.GetNewForm.GetNewDepartmentForm
{
    public class GetNewDepartmentFormQueryHandler : IGetNewDepartmentFormQueryHandler
    {
        private IFormSectionRepository _formSectionRepository;

        public GetNewDepartmentFormQueryHandler(IFormSectionRepository formSectionRepository) 
        { 
            _formSectionRepository = formSectionRepository;
        }

        public async Task<GetNewDepartmentFormQueryResult> HandleAsync(GetNewDepartmentFormQueryModel getNewFormQueryModel)
        {
            GetNewDepartmentFormQueryResult result = new GetNewDepartmentFormQueryResult();

            result.formSections = await _formSectionRepository.GetFormSectionsByCategoryIdAsync(getNewFormQueryModel.FormCategoryId);
            result.formSubSections = await _formSectionRepository.GetFormSubSectionsByCategoryIdAsync(getNewFormQueryModel.FormCategoryId);
            result.questions = await _formSectionRepository.GetFormQuestionsByCategoryIdAsync(getNewFormQueryModel.FormCategoryId);

            return result;
        }
    }
}

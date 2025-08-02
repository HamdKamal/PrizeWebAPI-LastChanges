using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.GetNewForm.GetNewIndividualForm
{
    public class GetNewIndividualFormQueryHandler: IGetNewIndividualFormQueryHandler
    {
        private IFormSectionRepository _formSectionRepository;
        private IFormSubSectionRepository _formSubSectionRepository;
        private IQuestionRepository _questionRepository;
        private IParticipantRepository _participantRepository;

        public GetNewIndividualFormQueryHandler(
            IFormSectionRepository formSectionRepository,
            IFormSubSectionRepository formSubSectionRepository,
            IQuestionRepository questionRepository,
            IParticipantRepository participantRepository
            )
        {
            _formSectionRepository = formSectionRepository;
            _formSubSectionRepository = formSubSectionRepository;
            _questionRepository = questionRepository;
            _participantRepository = participantRepository;
        }

        public async Task<GetNewIndividualFormQueryResult> HandleAsync(GetNewIndividualFormQueryModel getNewFormQueryModel)
        {
            GetNewIndividualFormQueryResult result = new GetNewIndividualFormQueryResult();

            result.formSections = await _formSectionRepository.GetFormSectionsByCategoryIdAsync(getNewFormQueryModel.FormCategoryId);
            result.formSubSections = await _formSectionRepository.GetFormSubSectionsByCategoryIdAsync(getNewFormQueryModel.FormCategoryId);
            result.questions = await _formSectionRepository.GetFormQuestionsByCategoryIdAsync(getNewFormQueryModel.FormCategoryId);

            return result;
        }
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFormSectionRepository
    {
        Task<List<FormSection>> GetFormSectionsByCategoryIdAsync(int categoryId);
        Task<List<FormSubSection>> GetFormSubSectionsByCategoryIdAsync(int categoryId);
        Task<List<Question>> GetFormQuestionsByCategoryIdAsync(int categoryId);

    }
}

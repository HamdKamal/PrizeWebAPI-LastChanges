using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FormSectionRepository: IFormSectionRepository
    {
        private readonly PrizeDbContext _context;

        public FormSectionRepository(PrizeDbContext context)
        {
            _context = context;
        }

        public async Task<List<FormSection>> GetFormSectionsByCategoryIdAsync(int categoryId)
        {
            return await _context.FormSections.Include(f => f.SubSections).ThenInclude(s=>s.Questions).ThenInclude(q=> q.QuestionType)
                .Include(f => f.SubSections).ThenInclude(s => s.Questions).ThenInclude(q => q.QuestionOptions).ThenInclude(qo=>qo.Option)
                .Where(f=> f.CategoryId.Equals(categoryId)).ToListAsync();
        }

        public async Task<List<FormSubSection>> GetFormSubSectionsByCategoryIdAsync(int categoryId)
        {
            var sections = await _context.FormSections.Include(f => f.SubSections).Where(f => f.CategoryId.Equals(categoryId)).ToListAsync();

            if (sections != null && sections.Count() > 0)
            {
                List<FormSubSection> subsections = new List<FormSubSection>();

                foreach (var section in sections)
                {
                    subsections.AddRange(section.SubSections);
                }

                return subsections;
            }

            return null;
        }

        public async Task<List<Question>> GetFormQuestionsByCategoryIdAsync(int categoryId)
        {
            var sections = await _context.FormSections.Include(f => f.SubSections)
                .ThenInclude(s=>s.Questions)
                .Where(f => f.CategoryId.Equals(categoryId)).ToListAsync();

            if (sections != null && sections.Count() > 0)
            {
                List<Question> questions = new List<Question>();

                foreach (var section in sections)
                {
                    foreach (var subsection in section.SubSections)
                    {
                        questions.AddRange(subsection.Questions);
                    }
                }

                return questions;
            }

            return null;
        }
    }
}

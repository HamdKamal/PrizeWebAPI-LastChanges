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
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly PrizeDbContext _context;

        public ParticipantRepository(PrizeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Participant>> AddRangeAsync(List<Participant> particpants)
        {
            _context.Participants.AddRange(particpants);
            await _context.SaveChangesAsync();
            return particpants;
        }

        public async Task<List<Participant>> UpdateRangeAsync(List<Participant> particpants)
        {
            _context.Participants.UpdateRange(particpants);
            await _context.SaveChangesAsync();
            return particpants;
        }

        public async Task DeleteRangeAsync(List<Participant> particpants)
        {
            _context.Participants.RemoveRange(particpants);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Participant>?> GetByFormSubmissionIdAsync(int formSubmissionId)
        {
            return await _context.Participants.Where(sa => sa.SubmissionId.Equals(formSubmissionId)).ToListAsync();
        }
    }
}

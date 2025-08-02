using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IParticipantRepository
    {
        Task<List<Participant>> AddRangeAsync(List<Participant> participants);
        Task<List<Participant>> UpdateRangeAsync(List<Participant> participants);
        Task DeleteRangeAsync(List<Participant> participants);
        Task<List<Participant>?> GetByFormSubmissionIdAsync(int formSubmissionId);
    }
}

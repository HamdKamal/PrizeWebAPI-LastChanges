using Application.Models.Common;
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
    public class UserRepository : IUserRepository
    {
        private readonly SWCCSharedDbContext _sapContext;
        public UserRepository(SWCCSharedDbContext sapContext) 
        {
            _sapContext = sapContext;
        }
        public async Task<VEmployeeRecordAll?> GetUserDetails(string userId)
        {
            var records = await _sapContext.VEmployeeRecordAll.Where(s => s.UID == userId).ToListAsync();
            if (records != null && records.Count > 0)
            {
                return records.First();
            }
            return null;
        }

        public async Task<List<VEmployeeRecordAll>?> GetUserList(List<string> userIds)
        {
            var records = await _sapContext.VEmployeeRecordAll.ToListAsync();
            if (records != null && records.Count > 0)
            {
                records = records.Where(s => (s.UID != null && s.UID.ToLower().StartsWith('u') && s.UID.Length == 7)).ToList();
                if (userIds != null && userIds.Count() > 0)
                    records = records.Where(s => userIds.Contains(s.UID)).ToList();
                return records;
            }
            return null;
        }

        public async Task<List<VEmployeeRecordAll>?> SearchUsers(string keyword)
        {
            var records = await _sapContext.VEmployeeRecordAll.ToListAsync();
            if (records != null && records.Count > 0)
            {
                int count = 0;
                records = records.Where(s => (s.UID != null && s.UID.ToLower().StartsWith('u') && s.UID.Length == 7) &&
                                             ((s.UID != null && s.UID.Contains(keyword)) ||
                                             (s.NationalId != null && s.NationalId.Contains(keyword)) ||
                                             (s.Mobile != null && s.Mobile.Contains(keyword)) ||
                                             (s.Extention != null && s.Extention.Contains(keyword)) ||
                                             (s.FirstNameAr != null && s.FirstNameAr.Contains(keyword)) ||
                                             (s.LastNameAr != null && s.LastNameAr.Contains(keyword)) ||
                                             (s.FirstNameEn != null && s.FirstNameEn.Contains(keyword)) ||
                                             (s.LastNameEn != null && s.LastNameEn.Contains(keyword)) ||
                                             (s.Mobile != null && s.Mobile.Contains(keyword)) ||
                                             (s.Email != null && s.Email.Contains(keyword)))).ToList();
                return records;
            }
            return null;
        }



    }

}

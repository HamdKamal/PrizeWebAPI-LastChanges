using Application.Abstractions.Common;
using Application.Models.Common;
using AutoMapper;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,
                           IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<ResponseResult<SAPUserInfoModel>> GetUserDetails(string uid)
        {
            var record = await _userRepository.GetUserDetails(uid);
            if (record != null)
            {
                SAPUserInfoModel sapModel = new SAPUserInfoModel()
                {
                    BrithDate = record.BirthDate,
                    DegreeCode = record.DegreeCode,
                    DepartmentCode = record.DepartmentCode,
                    DepartmentNameAr = record.DepartmentNameAr,
                    DivisionCode = record.DivisionCode,
                    Email = record.Email,
                    EmployeeName = record.FirstNameAr + " " + record.LastNameAr,
                    Extention = record.Extention,
                    IsSapUser = record.IsSapUser == 1,
                    JobDegree = record.JobDegree,
                    JobTitle = record.JobTitle,
                    Mobile = record.Mobile,
                    NationalId = record.NationalId,
                    UID = record.UID,
                    SectionCode = record.SectionCode,
                    LocationCode = record.LocationCode,
                    MajorCode = record.MajorCode,
                };
                return ResponseResult<SAPUserInfoModel>.Success(sapModel);
            }
            return null;
        }

        public async Task<ResponseResult<List<SAPUserInfoModel>>> GetUserList(List<string> userIds)
        {
            var records = await _userRepository.GetUserList(userIds);
            List<SAPUserInfoModel> result = new List<SAPUserInfoModel>();
            foreach (var record in records)
            {
                SAPUserInfoModel sapUser = _mapper.Map<SAPUserInfoModel>(record);
                result.Add(sapUser);
            }
            return ResponseResult<List<SAPUserInfoModel>>.Success(result);
        }

        public async Task<List<SAPUserInfoModel>> SearchUsers(string keyword)
        {
            var records = await _userRepository.SearchUsers(keyword);
            int count = 0;
            List<SAPUserInfoModel> result = new List<SAPUserInfoModel>();
            foreach (var record in records)
            {
                SAPUserInfoModel sapUser = _mapper.Map<SAPUserInfoModel>(record);
                result.Add(sapUser);
                count++;
                if (count == 20)
                    break;
            }
            return result;
        }
    }

}

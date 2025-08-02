using Application.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Common
{
    public interface IUserService
    {
        Task<ResponseResult<List<SAPUserInfoModel>>> GetUserList(List<string> userIds);
        Task<ResponseResult<SAPUserInfoModel>> GetUserDetails(string uid);
        Task<List<SAPUserInfoModel>> SearchUsers(string keyword);
        
    }

}

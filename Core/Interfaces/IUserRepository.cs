using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<VEmployeeRecordAll> GetUserDetails(string uid);
        Task<List<VEmployeeRecordAll>> GetUserList(List<string> userIds);
        Task<List<VEmployeeRecordAll>> SearchUsers(string keyword);
    }

}

using Application.Abstractions.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Common;
using System.Security.Claims;
using System.Data;

namespace Infrastructure.Services;

public enum RoleEnum
{
    Department = 1,
    Individual,

}

public class CurrentUserService : ICurrentUserService
{
    private readonly IAuthService _authService;
    public SAPUserInfoModel User { get; private set; }
    public List<RoleEnum> Roles { get; set; }


    public CurrentUserService(IAuthService authService, IHttpContextAccessor httpContextAccessor, IOptions<JWTModel> settings)
    {
        _authService = authService;
        User = new SAPUserInfoModel();
        if (httpContextAccessor != null && httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true)
        {
            User.EmployeeName = httpContextAccessor.HttpContext?.User?.FindFirstValue("EmployeeName");
            User.Mobile = httpContextAccessor.HttpContext?.User?.FindFirstValue("Mobile");
            int.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue("JobRank"), out int rank);
            User.JobRank = rank;
            User.JobTitle = httpContextAccessor.HttpContext?.User?.FindFirstValue("JobTitle");
            string jwtSecret = settings.Value.EncKey; //Secret key which will be used later during validation
            // User.UID = EncryptionService.DecryptString(httpContextAccessor.HttpContext?.User?.FindFirstValue("UID"), jwtSecret.Substring(0,16));
            User.UID = _authService.Decrypt(httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "uid")?.Value, jwtSecret); //httpContextAccessor.HttpContext?.User?.FindFirstValue("UID");
            User.Extention = httpContextAccessor.HttpContext?.User?.FindFirstValue("Extention");
            User.JobDegree = httpContextAccessor.HttpContext?.User?.FindFirstValue("JobDegree");
            User.Email = httpContextAccessor.HttpContext?.User?.FindFirstValue("Email");
            User.DepartmentNameAr = httpContextAccessor.HttpContext?.User?.FindFirstValue("DepartmentNameAr");
            //Roles = httpContextAccessor.HttpContext?.User?.FindFirstValue("Roles")?.Split(',')?.ToList().Select(s => Enum.Parse(typeof(RoleEnum), s)).Cast<RoleEnum>().ToList();
        }
    }
  
}


using Application.Abstractions.Common;
using Application.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PrizeWebAPI.Models;
using Core.Interfaces;

namespace PrizeWebAPI.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController(IUserService userService,
        ICurrentUserService currentUserService, IAuthService authService, IAdminRepository adminRepository) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        private readonly IUserService _userService = userService;
        private readonly ICurrentUserService _currentUserService = currentUserService;    
        private readonly IAdminRepository _adminRepository = adminRepository;

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                string uid;
                string fullName;

                bool isValid = _authService.ValidateToken(out uid, out fullName);

                if (!(isValid && _currentUserService != null && ((_currentUserService.User != null && uid == _currentUserService.User.UID) /*|| (currentUserService.Permissions != null && currentUserService.Permissions.Any())*/)))
                    return new UnauthorizedObjectResult(
                        ResponseResult<object?>.Failure(new List<string> { "Unauthorized Access" }, null)
                    );

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "An error occurred while retrieving User .",
                    Error = ex.Message
                });
            }
            //return Ok(await _userService.GetUserDetails(uid));
        }

        [HttpGet]
        public async Task<IActionResult> SearchUsers([FromQuery]string? keyword)
        {
            return Ok(await _userService.SearchUsers(keyword));
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetailsById([FromQuery] string uid)
        {
            
            try
            {
                var userDetails = await _userService.GetUserDetails(uid);
                if (userDetails != null && userDetails.Model != null)
                {
                    var result = new ParticipantDTO()
                    {
                        Department = userDetails.Model?.DepartmentNameAr ?? "",
                        MobileNumber = userDetails.Model?.Mobile ?? "",
                        Email = userDetails.Model?.Email ?? "",
                        Name = userDetails.Model?.EmployeeName ?? "",
                        JobTitle = userDetails.Model?.JobTitle ?? ""
                    };
                    return Ok(new ApiResponse<ParticipantDTO>
                    {
                        Success = true,
                        Message = "Participant retrieved successfully.",
                        Data = result
                    });
                }
                else
                {
                    return NotFound(new ApiResponse<ParticipantDTO>
                    {
                        Success = false,
                        Message = $"Participant with ID {uid} not found."
                    });
                }                
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<ParticipantDTO>
                {
                    Success = false,
                    Message = "An error occurred while retrieving the Participant.",
                    Error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> CheckUserRole([FromQuery] string uid)
        {
            try
            {
                bool isAdmin = await _adminRepository.IsAdmin(uid);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Role retrieved successfully.",
                    Data = new { IsAdmin = isAdmin, Role = isAdmin ? "Admin" : "User" }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "An error occurred while checking user role.",
                    Error = ex.Message
                });
            }
        }
    }

}


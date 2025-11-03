using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VoltSwap.BusinessLayer.Services;
using VoltSwap.Common.DTOs;

namespace VoltSwap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("user-information")]
        public async Task<IActionResult> GetUserUpdateInformation([FromQuery] UserRequest requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid input", errors = ModelState });
            }

            var getUserInformation = await _userService.GetDriverUpdateInformationAsync(requestDto);

            return StatusCode(getUserInformation.Status, new { message = getUserInformation.Message, data = getUserInformation.Data });
        }

        [HttpPut("update-user-information")]
        public async Task<IActionResult> UpdateUserInformation(DriverUpdate requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid input", errors = ModelState });
            }

            var updateDriverInformation = await _userService.UpdateDriverInformationAsync(requestDto);

            return StatusCode(updateDriverInformation.Status,
                            new
                            {
                                message = updateDriverInformation.Message,
                                data = updateDriverInformation.Data
                            });
        }

        [HttpGet("staff-information")]
        public async Task<IActionResult> GetStaffUpdateInformation([FromQuery] UserRequest requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid input", errors = ModelState });
            }

            var getStaffInformation = await _userService.GetStaffUpdateInformationAsync(requestDto);

            return StatusCode(getStaffInformation.Status,
                new
                {
                    message = getStaffInformation.Message,
                    data = getStaffInformation.Data
                });
        }

        [HttpPut("update-staff-information")]
        public async Task<IActionResult> UpdateStaffInformation(StaffUpdate requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid input", errors = ModelState });
            }

            var updateStaffInformation = await _userService.UpdateStaffInformationAsync(requestDto);

            return StatusCode(updateStaffInformation.Status,
                            new
                            {
                                message = updateStaffInformation.Message,
                                data = updateStaffInformation.Data
                            });
        }

        [HttpPost("delete-user")]
        public async Task<IActionResult> DeleteUserById([FromBody] UserRequest requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid input", errors = ModelState });
            }
            var deleteUser = await _userService.DeleteUserAsync(requestDto);
            return StatusCode(deleteUser.Status,
                            new
                            {
                                message = deleteUser.Message,
                                data = deleteUser.Data
                            });
        }

        [HttpGet("staff-list")]
        public async Task<IActionResult> GetStaffListByStationId()
        {
            var getStaffList = await _userService.GetAllStaffsAsync();
            return StatusCode(getStaffList.Status,
                            new
                            {
                                message = getStaffList.Message,
                                data = getStaffList.Data
                            });
        }

        [HttpPut("create-staff")]
        public async Task<IActionResult> CreateStaff(StaffCreateRequest request)
        {
            var createStaff = await _userService.CreateNewStaffAsync(request);
            return StatusCode(createStaff.Status,
                            new
                            {
                                message = createStaff.Message,
                                data = createStaff.Data
                            });
        }

        [HttpGet("driver-list")]
        public async Task<IActionResult> GetDriverList()
        {
            var getDriverList = await _userService.GetAllDriversAsync();
            return StatusCode(getDriverList.Status,
                            new
                            {
                                message = getDriverList.Message,
                                data = getDriverList.Data
                            });
        }

        [HttpGet("driver-detail")]
        public async Task<IActionResult> GetDriverDetailById([FromQuery] UserRequest requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid input", errors = ModelState });
            }
            var getDriverDetail = await _userService.GetDriverDetailInformationAsync(requestDto);
            return StatusCode(getDriverDetail.Status,
                            new
                            {
                                message = getDriverDetail.Message,
                                data = getDriverDetail.Data
                            });
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(new
            {
                message = "API ĐÃ KẾT NỐI THÀNH CÔNG TỪ NGROK!",
                time = DateTime.UtcNow,
                origin = Request.Headers["Origin"]
            });
        }
    } // ← Đóng class
} // ← Đóng namespace → ĐÚNG

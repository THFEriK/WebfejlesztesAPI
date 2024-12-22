using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebfejlesztesAPI.Services;
using WebfejlesztesAPI.Services.Dto;
using WebfejlesztesAPI.Services.Impl;

namespace WebfejlesztesAPI.Controllers
{
    [Route("api/charter")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CharterController : ControllerBase
    {
        private readonly CharterManagmentService _charterManagmentService;
        public CharterController(CharterManagmentService charterManagmentService)
        {
            _charterManagmentService = charterManagmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CharterDto>>> GetCharters()
        {
            return await _charterManagmentService.FindAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharterDto>> GetCharter(int id)
        {
            return await _charterManagmentService.FindById(id);
        }

        [HttpPost]
        public async Task<ActionResult<CharterDto>> CreateCharter([FromBody] CharterDto dto)
        {
            return await _charterManagmentService.Save(dto);
        }

        [HttpPut]
        public async Task<ActionResult<CharterDto>> UpdateCharter([FromBody] CharterDto dto)
        {
            return await _charterManagmentService.Update(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharter(int id)
        {
            return await _charterManagmentService.Delete(id);
        }
    }
}

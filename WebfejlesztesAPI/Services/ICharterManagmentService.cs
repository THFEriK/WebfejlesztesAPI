using Microsoft.AspNetCore.Mvc;
using WebfejlesztesAPI.Services.Dto;

namespace WebfejlesztesAPI.Services
{
    public interface ICharterManagmentService
    {
        Task<ActionResult<CharterDto>> Save(CharterDto dto);
        Task<ActionResult<List<CharterDto>>> FindAll();
        Task<ActionResult<CharterDto>> FindById(long id);
        Task<ActionResult<CharterDto>> Update(CharterDto dto);
        Task<ActionResult> Delete(long id);
    }
}

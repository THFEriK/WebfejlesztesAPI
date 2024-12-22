using Domain.Entities;
using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebfejlesztesAPI.Services.Dto;

namespace WebfejlesztesAPI.Services.Impl
{
    public class CharterManagmentService : ICharterManagmentService
    {
        private readonly WebDbContext _dbContext;

        public CharterManagmentService(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult> Delete(long id)
        {
            var result = await _dbContext.Charters.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return new NotFoundResult();
            }

            _dbContext.Charters.Remove(result);

            await _dbContext.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult<List<CharterDto>>> FindAll()
        {
            var results = await _dbContext.Charters.ToListAsync();
            var dtos = results.Select(c => new CharterDto
            {
                Id = c.Id,
                Arrival = c.Arrival,
                Departure = c.Departure,
                ArrivalTime = c.ArrivalTime,
                DepartureTime = c.DepartureTime,
            }).ToList();

            return new ActionResult<List<CharterDto>>(dtos);
        }

        public async Task<ActionResult<CharterDto>> FindById(long id)
        {
            var result = await _dbContext.Charters.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return new NotFoundResult();
            }

            var dto = new CharterDto
            {
                Id = result.Id,
                Arrival = result.Arrival,
                Departure = result.Departure,
                ArrivalTime = result.ArrivalTime,
                DepartureTime = result.DepartureTime,
            };

            return new OkObjectResult(dto);
        }

        public async Task<ActionResult<CharterDto>> Save(CharterDto dto)
        {
            var charterEntity = new CharterEntity
            {
                Arrival = dto.Arrival,
                Departure = dto.Departure,
                ArrivalTime = dto.ArrivalTime,
                DepartureTime = dto.DepartureTime,
            };

            _dbContext.Charters.Add(charterEntity);

            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(dto);
        }

        public async Task<ActionResult<CharterDto>> Update(CharterDto dto)
        {
            var charterEntity = new CharterEntity
            {
                Id = dto.Id,
                Arrival = dto.Arrival,
                Departure = dto.Departure,
                ArrivalTime = dto.ArrivalTime,
                DepartureTime = dto.DepartureTime,
            };

            _dbContext.Charters.Update(charterEntity);

            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(dto);
        }
    }
}

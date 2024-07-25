using AutoMapper;
using BookingV2.Logic.Contract;
using BookingV2.Logic.Models;
using BookinV2.Data.Entities.RealEstateEntities;
using BookinV2API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookingV2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IRealEstateService _realEstateService;
        private readonly IMapper _mapper;

        public RealEstateController(IRealEstateService realEstateService, IMapper mapper)
        {
            this._realEstateService = realEstateService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await this._realEstateService.GetAllAsync();

            if (!response.IsSucceeded)
            {
                return this.StatusCode(500, response.Errors);
            }

            var realEstateDtos = this._mapper.Map<IEnumerable<RealEstateDto>>(response.Response);
            return this.Ok(realEstateDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await this._realEstateService.GetByIdAsync(id);

            if (!response.IsSucceeded)
            {
                return this.NotFound(response.Errors);
            }

            var realEstateDto = this._mapper.Map<RealEstateDto>(response.Response);
            return this.Ok(realEstateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RealEstateDto realEstateDto)
        {
            var realEstate = this._mapper.Map<RealEstateModel>(realEstateDto);
            var response = await this._realEstateService.AddAsync(realEstate);

            if (!response.IsSucceeded)
            {
                return this.StatusCode(500, response.Errors);
            }

            var createdDto = this._mapper.Map<RealEstateDto>(response.Response);
            return this.CreatedAtAction(nameof(this.GetById), new { id = createdDto.Id }, createdDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RealEstateDto realEstateDto)
        {
            if (id != realEstateDto.Id)
            {
                return this.BadRequest("ID mismatch.");
            }

            var realEstate = this._mapper.Map<RealEstateModel>(realEstateDto);
            var response = await this._realEstateService.UpdateAsync(realEstate);

            if (!response.IsSucceeded)
            {
                return this.NotFound(response.Errors);
            }

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await this._realEstateService.DeleteAsync(id);

            if (!response.IsSucceeded)
            {
                return this.NotFound(response.Errors);
            }

            return this.NoContent();
        }
    }
}

using AutoMapper;
using BookingV2.Logic.Contract;
using BookingV2.Logic.Models;
using BookinV2API.Models.DTOs;
using BookinV2API.Responses;
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
            var serviceResult = await this._realEstateService.GetAllAsync();
            var response = new ApiResponse<IEnumerable<RealEstateDto>>
            {
                IsSucceeded = serviceResult.IsSuccessful,
                Response = this._mapper.Map<IEnumerable<RealEstateDto>>(serviceResult.Response),
                Errors = serviceResult.Errors,
            };

            return this.Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var serviceResult = await this._realEstateService.GetByIdAsync(id);
            var response = new ApiResponse<RealEstateDto>
            {
                IsSucceeded = serviceResult.IsSuccessful,
                Response = this._mapper.Map<RealEstateDto>(serviceResult.Response),
                Errors = serviceResult.Errors,
            };

            if (!serviceResult.IsSuccessful)
            {
                return this.NotFound(response);
            }

            return this.Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RealEstateDto realEstateDto)
        {
            var realEstate = this._mapper.Map<RealEstateModel>(realEstateDto);
            var serviceResult = await this._realEstateService.AddAsync(realEstate);
            var response = new ApiResponse<RealEstateDto>
            {
                IsSucceeded = serviceResult.IsSuccessful,
                Response = this._mapper.Map<RealEstateDto>(serviceResult.Response),
                Errors = serviceResult.Errors,
            };

            if (!serviceResult.IsSuccessful)
            {
                return this.BadRequest(response);
            }

            return this.CreatedAtAction(nameof(this.GetById), new { id = response.Response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RealEstateDto realEstateDto)
        {
            var realEstate = this._mapper.Map<RealEstateModel>(realEstateDto);
            realEstate.Id = id;
            var serviceResult = await this._realEstateService.UpdateAsync(realEstate);
            var response = new ApiResponse<RealEstateDto>
            {
                IsSucceeded = serviceResult.IsSuccessful,
                Response = this._mapper.Map<RealEstateDto>(serviceResult.Response),
                Errors = serviceResult.Errors,
            };

            if (!serviceResult.IsSuccessful)
            {
                return this.BadRequest(response);
            }

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return this.NoContent();
        }
    }
}

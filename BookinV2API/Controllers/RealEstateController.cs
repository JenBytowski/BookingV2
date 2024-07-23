using BookingV2.Logic.Contract;
using BookinV2.Data.Entities.RealEstateEntities;
using Microsoft.AspNetCore.Mvc;

namespace BookinV2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IRealEstateService _realEstateService;

        public RealEstateController(IRealEstateService realEstateService)
        {
            this._realEstateService = realEstateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await this._realEstateService.GetAllAsync();

            if (!response.IsSucceeded)
            {
                return this.StatusCode(500, response);
            }

            return this.Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await this._realEstateService.GetByIdAsync(id);

            if (!response.IsSucceeded)
            {
                return this.NotFound(response);
            }

            return this.Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstate realEstate)
        {
            var response = await this._realEstateService.AddAsync(realEstate);
            if (!response.IsSucceeded)
            {
                return this.StatusCode(500, response);
            }

            return this.CreatedAtAction(nameof(this.GetById), new { id = realEstate.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RealEstate realEstate)
        {
            if (id != realEstate.Id)
            {
                return this.BadRequest();
            }

            var response = await this._realEstateService.UpdateAsync(realEstate);
            if (!response.IsSucceeded)
            {
                return this.NotFound(response);
            }

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await this._realEstateService.DeleteAsync(id);
            if (!response.IsSucceeded)
            {
                return this.NotFound(response);
            }

            return this.NoContent();
        }
    }
}

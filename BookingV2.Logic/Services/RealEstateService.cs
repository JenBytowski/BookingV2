using BookingV2.Logic.Contract;
using BookingV2.Logic.Responses;
using BookinV2.Data;
using BookinV2.Data.Entities.RealEstateEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingV2.Logic.Services
{
    public class RealEstateService : IRealEstateService
    {
        private readonly BookingV2DBContext _context;
        private readonly ILogger<RealEstateService> _logger;

        public RealEstateService(BookingV2DBContext context, ILogger<RealEstateService> logger)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResponse<IEnumerable<RealEstate>>> GetAllAsync()
        {
            var response = new ApiResponse<IEnumerable<RealEstate>>();

            try
            {
                if (this._context.RealEstates == null)
                {
                    response.AddError("RealEstate DbSet is null.");
                    return response;
                }

                response.Response = await this._context.RealEstates.ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Failed to get all RealEstates: {ex.Message}");
                response.AddError("An error occurred while fetching data.");
            }

            return response;
        }

        public async Task<ApiResponse<RealEstate>> GetByIdAsync(int id)
        {
            var response = new ApiResponse<RealEstate>();

            try
            {
                if (this._context.RealEstates == null)
                {
                    response.AddError("RealEstate DbSet is null.");
                    return response;
                }

                var realEstate = await this._context.RealEstates.FindAsync(id);

                if (realEstate == null)
                {
                    response.AddError("RealEstate not found.");
                    return response;
                }

                response.Response = realEstate;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Failed to get RealEstate by id {id}: {ex.Message}");
                response.AddError("An error occurred while fetching data.");
            }

            return response;
        }

        public async Task<ApiResponse<RealEstate>> AddAsync(RealEstate realEstate)
        {
            var response = new ApiResponse<RealEstate>();

            try
            {
                if (this._context.RealEstates == null)
                {
                    response.AddError("RealEstate DbSet is null.");
                    return response;
                }

                this._context.RealEstates.Add(realEstate);
                await this._context.SaveChangesAsync();
                response.Response = realEstate;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Failed to add RealEstate: {ex.Message}");
                response.AddError("An error occurred while adding data.");
            }

            return response;
        }

        public async Task<ApiResponse<RealEstate>> UpdateAsync(RealEstate realEstate)
        {
            var response = new ApiResponse<RealEstate>();
            try
            {
                if (this._context.RealEstates == null)
                {
                    response.AddError("RealEstate DbSet is null.");
                    return response;
                }

                var existingRealEstate = await this._context.RealEstates.FindAsync(realEstate.Id);

                if (existingRealEstate == null)
                {
                    response.AddError("RealEstate not found.");
                    return response;
                }

                this._context.Entry(existingRealEstate).CurrentValues.SetValues(realEstate);
                await this._context.SaveChangesAsync();
                response.Response = existingRealEstate;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Failed to update RealEstate: {ex.Message}");
                response.AddError("An error occurred while updating data.");
            }

            return response;
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                if (this._context.RealEstates == null)
                {
                    response.AddError("RealEstate DbSet is null.");
                    response.Response = false;
                    return response;
                }

                var realEstate = await this._context.RealEstates.FindAsync(id);

                if (realEstate == null)
                {
                    response.AddError("RealEstate not found.");
                    response.Response = false;
                    return response;
                }

                this._context.RealEstates.Remove(realEstate);
                await this._context.SaveChangesAsync();
                response.Response = true;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Failed to delete RealEstate: {ex.Message}");
                response.AddError("An error occurred while deleting data.");
                response.Response = false;
            }

            return response;
        }
    }
}

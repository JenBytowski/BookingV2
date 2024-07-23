using BookingV2.Logic.Responses;
using BookinV2.Data.Entities.RealEstateEntities;

namespace BookingV2.Logic.Contract
{
    public interface IRealEstateService
    {
        Task<ApiResponse<IEnumerable<RealEstate>>> GetAllAsync();

        Task<ApiResponse<RealEstate>> GetByIdAsync(int id);

        Task<ApiResponse<RealEstate>> AddAsync(RealEstate realEstate);

        Task<ApiResponse<RealEstate>> UpdateAsync(RealEstate realEstate);

        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}

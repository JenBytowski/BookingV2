using BookingV2.Logic.Responses;
using BookinV2.Data.Entities.RealEstateEntities;

namespace BookingV2.Logic.Contract
{
    public interface IRealEstateService
    {
        Task<ServiceResult<IEnumerable<RealEstateDto>>> GetAllAsync();

        Task<ServiceResult<RealEstateDto>> GetByIdAsync(int id);

        Task<ServiceResult<RealEstateDto>> AddAsync(RealEstateDto realEstate);

        Task<ServiceResult<RealEstateDto>> UpdateAsync(RealEstateDto realEstate);

        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}

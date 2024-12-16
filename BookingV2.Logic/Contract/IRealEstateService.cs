using BookingV2.Logic.Models;
using BookingV2.Logic.Responses;
using BookinV2.Data.Entities.RealEstateEntities;

namespace BookingV2.Logic.Contract
{
    public interface IRealEstateService
    {
        Task<ServiceResult<IEnumerable<RealEstateModel>>> GetAllAsync();

        Task<ServiceResult<RealEstateModel>> GetByIdAsync(int id);

        Task<ServiceResult<RealEstateModel>> AddAsync(RealEstateModel realEstate);

        Task<ServiceResult<RealEstateModel>> UpdateAsync(RealEstateModel realEstate);

        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}

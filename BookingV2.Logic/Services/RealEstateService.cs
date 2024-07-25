using BookingV2.Logic.Contract;
using BookingV2.Logic.Responses;
using BookinV2.Data.Entities.RealEstateEntities;
using BookinV2.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingV2.Logic.Services
{
    public class RealEstateService : IRealEstateService
    {
        private readonly IBookinV2DataContext _context;
        private readonly ILogger<RealEstateService> _logger;

        public RealEstateService(IBookinV2DataContext context, ILogger<RealEstateService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ServiceResult<IEnumerable<RealEstateDto>>> GetAllAsync()
        {
            var response = new ServiceResult<IEnumerable<RealEstateDto>>();

            var realEstates = await _context.Get<RealEstateDto>().ToListAsync();
            response.Response = realEstates;

            return response;
        }

        public async Task<ServiceResult<RealEstateDto>> GetByIdAsync(int id)
        {
            var response = new ServiceResult<RealEstateDto>();

            var realEstate = await _context.Get<RealEstateDto>().FirstOrDefaultAsync(re => re.Id == id);

            if (realEstate == null)
            {
                response.AddError("RealEstate not found.");
                return response;
            }

            response.Response = realEstate;

            return response;
        }

        public async Task<ServiceResult<RealEstateDto>> AddAsync(RealEstateDto realEstate)
        {
            var response = new ServiceResult<RealEstateDto>();

            if(string.IsNullOrWhiteSpace(realEstate.Address))
            {
                response.AddError("Address is required.");
            }
            if (realEstate.Square <= 0)
            {
                response.AddError("Square must be greater than zero.");
            }
            if (realEstate.RoomCount <= 0)
            {
                response.AddError("Room count must be greater than zero.");
            }

            if (response.Errors.Count > 0)
            {
                return response;
            }

            _context.Create(realEstate);
            await _context.SubmitChangesAsync(CancellationToken.None);
            response.Response = realEstate;

            return response;
        }

        public async Task<ServiceResult<RealEstateDto>> UpdateAsync(RealEstateDto realEstate)
        {
            var response = new ServiceResult<RealEstateDto>();

            var existingRealEstate = await _context.Get<RealEstateDto>().FirstOrDefaultAsync(re => re.Id == realEstate.Id);

            if (existingRealEstate == null)
            {
                response.AddError("RealEstate not found.");
                return response;
            }

            _context.Create(realEstate);
            await _context.SubmitChangesAsync(CancellationToken.None);
            response.Response = realEstate;

            return response;
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var response = new ServiceResult<bool>();

            var realEstate = await _context.Get<RealEstateDto>().FirstOrDefaultAsync(re => re.Id == id);

            if (realEstate == null)
            {
                response.AddError("RealEstate not found.");
                response.Response = false;
                return response;
            }

            _context.Create(realEstate);
            await _context.SubmitChangesAsync(CancellationToken.None);
            response.Response = true;

            return response;
        }
    }
}

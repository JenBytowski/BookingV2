using BookingV2.Logic.Contract;
using BookingV2.Logic.Models;
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

        public async Task<ServiceResult<IEnumerable<RealEstateModel>>> GetAllAsync()
        {
            var response = new ServiceResult<IEnumerable<RealEstateModel>>();

            var realEstates = await _context.Get<RealEstate>().Select(realEstates =>
                new RealEstateModel
                {
                    Address = realEstates.Address,
                    Id = realEstates.Id,
                    Square = realEstates.Square,
                    RoomCount = realEstates.RoomCount,
                }
            ).ToListAsync();

            response.Response = realEstates;

            return response;
        }

        public async Task<ServiceResult<RealEstateModel>> GetByIdAsync(int id)
        {
            var response = new ServiceResult<RealEstateModel>();

            var realEstate = await _context.Get<RealEstate>().Select(realEstates =>
                new RealEstateModel
                {
                    Address = realEstates.Address,
                    Id = realEstates.Id,
                    Square = realEstates.Square,
                    RoomCount = realEstates.RoomCount,
                }
            ).FirstOrDefaultAsync(re => re.Id == id);

            if (realEstate == null)
            {
                response.AddError("RealEstate not found.");
                return response;
            }

            response.Response = realEstate;

            return response;
        }

        public async Task<ServiceResult<RealEstateModel>> AddAsync(RealEstateModel realEstate)
        {
            var response = new ServiceResult<RealEstateModel>();

            if (string.IsNullOrWhiteSpace(realEstate.Address))
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

            RealEstate realEstateEntity = new RealEstate
            {
                Address = realEstate.Address,
                Id = realEstate.Id,
                Square = realEstate.Square,
                RoomCount = realEstate.RoomCount,
            };

            _context.Create(realEstateEntity);
            await _context.SubmitChangesAsync(CancellationToken.None);
            response.Response = realEstate;

            return response;
        }

        public async Task<ServiceResult<RealEstateModel>> UpdateAsync(RealEstateModel realEstate)
        {
            var response = new ServiceResult<RealEstateModel>();

            if (string.IsNullOrWhiteSpace(realEstate.Address))
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

            var existingRealEstate = await _context.Get<RealEstate>()
                                                   .FirstOrDefaultAsync(re => re.Id == realEstate.Id);

            if (existingRealEstate == null)
            {
                response.AddError("RealEstate not found.");
                return response;
            }

            existingRealEstate.Address = realEstate.Address;
            existingRealEstate.Square = realEstate.Square;
            existingRealEstate.RoomCount = realEstate.RoomCount;

            await _context.SubmitChangesAsync(CancellationToken.None);

            response.Response = realEstate;

            return response;
        }

        public Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

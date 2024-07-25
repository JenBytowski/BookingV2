namespace BookingV2.Logic.Models
{
    public class AdvertisementDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int RealEstateId { get; set; }

        public AdvertisementDto? RealEstate { get; set; }
    }
}
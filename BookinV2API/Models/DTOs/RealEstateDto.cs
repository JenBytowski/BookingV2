namespace BookinV2API.Models.DTOs
{
    public class RealEstateDto
    {
        public int Id { get; set; }

        public string Address { get; set; } = string.Empty;

        public int Square { get; set; }

        public int RoomCount { get; set; }
    }
}

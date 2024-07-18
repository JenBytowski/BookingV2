namespace BookinV2.Data.Entities.RealEstateEntities
{
    public class Advertisement : BaseEntity
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int RealEstateId { get; set; }

        public Advertisement? RealEstate { get; set; }
    }
}

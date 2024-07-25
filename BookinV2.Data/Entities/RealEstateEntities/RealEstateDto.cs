namespace BookinV2.Data.Entities.RealEstateEntities
{
    public class RealEstate : BaseEntity
    {
        public string Address { get; set; }

        public int Square { get; set; }

        public int RoomCount { get; set; }
    }
}

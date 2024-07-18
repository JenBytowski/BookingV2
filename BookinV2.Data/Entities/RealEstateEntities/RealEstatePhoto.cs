using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookinV2.Data.Entities.RealEstateEntities
{
    public class RealEstatePhoto : BaseEntity
    {
        public int RealEstateId { get; set; }

        public string Photo { get; set; }
    }
}

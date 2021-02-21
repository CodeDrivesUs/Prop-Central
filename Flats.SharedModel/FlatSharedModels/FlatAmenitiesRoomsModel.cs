using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.FlatSharedModels
{
   public  class FlatAmenitiesRoomsModel
    {
        public Guid FlatId { get; set; }
        public Guid AmenityId { get; set; }
        public Guid RoomTypeId { get; set; }
        public int Type { get; set; }
        public decimal Deposit { get; set; }
        public decimal Rent { get; set; }

    }
}

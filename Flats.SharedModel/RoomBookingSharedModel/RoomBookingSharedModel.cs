using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.RoomBookingSharedModel
{
    public class RoomBookingSharedModel:BasePrimaryKey
    {
        public Guid UseriId { get; set; }
        public Guid RoomTypeId { get; set; }
        public Guid FlatId { get; set; }
        public DateTime BookingCreationDate { get; set; }
        public DateTime BookingDate { get; set; }
        public string IdNumber { get; set; }
    }
}

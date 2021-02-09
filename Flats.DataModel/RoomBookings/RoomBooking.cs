using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataModel.RoomBookings
{
    public class RoomBooking:BasePrimaryKey
    {
        public Guid UseriId { get; set; }
        public Guid RoomTypeId { get; set; }
        public Guid FlatId { get; set; }
        public DateTime BookingCreationDate { get; set; }
        public string IdNumber { get; set; }

    }
}

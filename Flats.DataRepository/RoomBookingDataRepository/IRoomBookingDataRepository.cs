using Flats.DataModel.RoomBookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.RoomBookingDataRepository
{
    public interface IRoomBookingDataRepository
    {
        Guid AddRoomBooking(RoomBooking roomBooking);
        IEnumerable<UserRoomBooking> GetRoomBookingsForAFlat(Guid FlatId);
        UserRoomBooking GetRoomBookingsById(Guid bookingId);
    }
}

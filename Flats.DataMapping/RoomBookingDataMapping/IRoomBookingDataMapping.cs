using Flats.DataModel.RoomBookings;
using Flats.SharedModel.RoomBookingSharedModel;
using Flats.SharedModel.RoomOccupantSharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.RoomBookingDataMapping
{
    public interface IRoomBookingDataMapping
    {
        Guid AddRoomBooking(RoomBookingSharedModel roomBookingSharedModel);
        IEnumerable<UserRoomBooingSharedModel> GetFlatBookingForAFlat(Guid FlatId);
        UserRoomBooingSharedModel GetRoomBookingById(Guid bookingId);
        RoomOccupantSharedModel PopulateRoomOccupantByBookingId(Guid Id);
    }
}

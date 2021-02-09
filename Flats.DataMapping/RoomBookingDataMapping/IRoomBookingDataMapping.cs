using Flats.SharedModel.RoomBookingSharedModel;
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
    }
}

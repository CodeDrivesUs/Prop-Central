using Flats.SharedModel.RoomBookingSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.RoomBookingBusiness
{
    public interface IRoomBookingBusiness
    {
        Guid AddRoomBooking(RoomBookingSharedModel roomBookingSharedModel);
    }
}

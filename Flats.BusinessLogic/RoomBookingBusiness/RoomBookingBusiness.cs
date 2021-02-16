using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flats.SharedModel.RoomBookingSharedModel;
using Flats.DataMapping.RoomBookingDataMapping;

namespace Flats.BusinessLogic.RoomBookingBusiness
{
    public class RoomBookingBusiness:IRoomBookingBusiness
    {
        private IRoomBookingDataMapping _roomBookingDataMapping;
        public RoomBookingBusiness()
        {
            _roomBookingDataMapping = new RoomBookingDataMapping();
        }
        public Guid AddRoomBooking(RoomBookingSharedModel roomBookingSharedModel)
        {
            return _roomBookingDataMapping.AddRoomBooking(roomBookingSharedModel);
        }
        public List<UserRoomBooingSharedModel> GetRoomBookingsForAFlat(Guid flatId)
        {
            return _roomBookingDataMapping.GetFlatBookingForAFlat(flatId).ToList();
        }
        public UserRoomBooingSharedModel GetRoomBookingById(Guid bookingId)
        {
            return _roomBookingDataMapping.GetRoomBookingById(bookingId);
        }
    }
}

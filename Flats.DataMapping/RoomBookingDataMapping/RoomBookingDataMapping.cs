using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flats.SharedModel.RoomBookingSharedModel;
using Flats.DataModel.RoomBookings;
using Flats.DataRepository.RoomBookingDataRepository;
using AutoMapper;
using Flats.DataMapping.AutoMapper;
using Flats.SharedModel.RoomOccupantSharedModels;

namespace Flats.DataMapping.RoomBookingDataMapping
{
    public class RoomBookingDataMapping:IRoomBookingDataMapping
    {
        IMapper mapper = new AutoMapperInit().GetMapperConfig().CreateMapper();
        private IRoomBookingDataRepository _dataRepository;
        public RoomBookingDataMapping()
        {
            _dataRepository = new RoomBookingDataRepository();
        }
        public Guid AddRoomBooking(RoomBookingSharedModel roomBookingSharedModel)
        {
            var dbModel = mapper.Map<RoomBooking>(roomBookingSharedModel);
          return   _dataRepository.AddRoomBooking(dbModel);
        }
        public IEnumerable<UserRoomBooingSharedModel> GetFlatBookingForAFlat(Guid FlatId)
        {
            return mapper.Map<IEnumerable<UserRoomBooingSharedModel>>(_dataRepository.GetRoomBookingsForAFlat(FlatId));
        }
        public UserRoomBooingSharedModel GetRoomBookingById(Guid bookingId)
        {
            return mapper.Map<UserRoomBooingSharedModel>(_dataRepository.GetRoomBookingsById(bookingId));

        }
        public RoomOccupantSharedModel PopulateRoomOccupantByBookingId(Guid Id)
        {
            var dbmodel = _dataRepository.GetRoomBookingsById(Id);
            return mapper.Map< UserRoomBooking , RoomOccupantSharedModel>(dbmodel);
        }
    }
}

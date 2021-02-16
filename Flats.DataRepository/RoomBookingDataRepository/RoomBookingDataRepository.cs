using Flats.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flats.DataModel.RoomBookings;
using Flats.Enums.RoomBookingEnums;
using Dapper;
using System.Data;

namespace Flats.DataRepository.RoomBookingDataRepository
{
    public class RoomBookingDataRepository:IRoomBookingDataRepository
    {
        private IRepository _repository;

        public RoomBookingDataRepository()
        {
            _repository = new Repository.Repository();
        }

        public Guid AddRoomBooking(RoomBooking roomBooking)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@IdNumber", roomBooking.IdNumber);
            sqlParameters.Add("@UserId",roomBooking.UseriId);
            sqlParameters.Add("@FlatRoomTypeId", roomBooking.RoomTypeId);
            sqlParameters.Add("@FlatId",roomBooking.FlatId );
            sqlParameters.Add("@bookingDate", roomBooking.BookingDate);
            sqlParameters.Add("@statusId", (int)RoomBookingEnums.BookingSubmitted);
           return _repository.SelectOne<Guid>("AddRoomBooking", sqlParameters, CommandType.StoredProcedure);
        }
        public IEnumerable<UserRoomBooking> GetRoomBookingsForAFlat(Guid FlatId)
        {
            var sqlParameters = new DynamicParameters();          
            sqlParameters.Add("@FlatId", FlatId);
            sqlParameters.Add("@statusId", (int)RoomBookingEnums.BookingSubmitted);
            return _repository.Query<UserRoomBooking>("GetAllRoomBookingsForAFlat", sqlParameters, CommandType.StoredProcedure);
        }
        public UserRoomBooking GetRoomBookingsById(Guid bookingId)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@bookingId", bookingId);
            return _repository.SelectOne<UserRoomBooking>("GetRoomBookingById", sqlParameters, CommandType.StoredProcedure);
        }
    }
}

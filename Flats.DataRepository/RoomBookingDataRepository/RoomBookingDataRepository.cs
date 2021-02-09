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
            sqlParameters.Add("@StatuId", (int)RoomBookingEnums.BookingSubmitted);
           return _repository.SelectOne<Guid>("AddRoomBooking", sqlParameters, CommandType.StoredProcedure);
        }
    }
}

using Dapper;
using Flats.DataModel.Rooms;
using Flats.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.RoomDataRepository
{
    public class RoomDataRepository:IRoomDataRepository
    {
        private IRepository _repository;


        public RoomDataRepository()
        {
            _repository = new Repository.Repository();
        }
        public void AddRoom(CreateUpdateRoom createUpdateRoom)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@roomtypeId", createUpdateRoom.RoomTypeId);
            sqlParameters.Add("@roomNumber", createUpdateRoom.RoomNumber);
            sqlParameters.Add("@flatId", createUpdateRoom.FlatId);
            sqlParameters.Add("@gender",(int)createUpdateRoom.Gender);
            _repository.ExecuteNonQuery("AddFlatRoom", sqlParameters, CommandType.StoredProcedure);
        }
    }
}

using Dapper;
using Flats.DataModel.RoomType;
using Flats.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.RoomTypeDataRepository
{
    public class RoomTypeDataRepository:IRoomTypeDataRepository
    {
        private IRepository _repository;


        public RoomTypeDataRepository()
        {
            _repository = new Repository.Repository();
        }
        public IEnumerable<RoomType> GetAll()
        {
            var query = @"SELECT * FROM [dbo].[RoomTypes] ORDER BY Id;";
            return  _repository.Query<RoomType>(query, null, CommandType.Text);
        }
        public IEnumerable<RoomType> GetRoomTypeByFlatId(Guid FlatId)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@flatId", FlatId);
            return _repository.Query<RoomType>("GetFlatRoomTypes", sqlParameters, CommandType.StoredProcedure);
        }

    }
}

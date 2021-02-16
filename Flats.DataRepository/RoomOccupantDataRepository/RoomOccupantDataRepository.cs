using Dapper;
using Flats.DataModel.RoomOccupant;
using Flats.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.RoomOccupantDataRepository
{
    public class RoomOccupantDataRepository:IRoomOccupantDataRepository
    {
        private IRepository _repository;


        public RoomOccupantDataRepository()
        {
            _repository = new Repository.Repository();
        }
        public Guid AddRoomOccupant(RoomOccupant roomOccupant )
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@DateIn", roomOccupant.DateIn);
            sqlParameters.Add("@DateOut", roomOccupant.DateOut);
            sqlParameters.Add("Email", roomOccupant.Email);
            sqlParameters.Add("@FirstName", roomOccupant.FirstName);
            sqlParameters.Add("@Gender",(int)roomOccupant.Gender);
            sqlParameters.Add("@IdNumber", roomOccupant.IdNumber);
            sqlParameters.Add("LastName", roomOccupant.LastName);
            sqlParameters.Add("@PhoneNumber", roomOccupant.PhoneNumber);
            sqlParameters.Add("@StatusId",(int)roomOccupant.StatusId);
            return _repository.SelectOne<Guid>("AddFlatRoom", sqlParameters, CommandType.StoredProcedure);
        }
    }
}

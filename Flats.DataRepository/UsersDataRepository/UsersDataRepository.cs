using Dapper;
using Flats.DataModel.Users;
using Flats.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.UsersDataRepository
{
    public  class UsersDataRepository:IUsersDataRepository
    {
        private IRepository _repository;


        public UsersDataRepository()
        {
            _repository = new Repository.Repository();
        }
        public IEnumerable<User> GetAllUsersExeptStaff()
        {
            return _repository.Query<User>("GetAllUsersExeptStaff", null, CommandType.StoredProcedure);
        }
        public User GetUserbyId(Guid UserId)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@userid", UserId);
            return _repository.SelectOne<User>("GetUserById", sqlParameters, CommandType.StoredProcedure);
        }

    }
}

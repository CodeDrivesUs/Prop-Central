using Flats.DataMapping.UsersDataMappings;
using Flats.SharedModel.UserSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.UsereBusiness
{
    public class UsereBusiness:IUsereBusiness
    {
        private IUsersDataMappings _dataMapping;
        public UsereBusiness()
        {
            _dataMapping = new UsersDataMappings();
        }

        public List<UserSharedModel> GetAllUsers()
        {
            return _dataMapping.GetAllUsersExeptStaff().ToList();
        }
        public UserSharedModel GetUserById(Guid UserId)
        {
            return _dataMapping.GetUserbyId(UserId);
        }
    }
}

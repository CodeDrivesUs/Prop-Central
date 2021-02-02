using Flats.SharedModel.UserSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.UsersDataMappings
{
    public interface IUsersDataMappings
    {
        IEnumerable<UserSharedModel> GetAllUsersExeptStaff();
        UserSharedModel GetUserbyId(Guid UserId);
    }
}

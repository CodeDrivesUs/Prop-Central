using Flats.DataModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.UsersDataRepository
{
    public interface IUsersDataRepository
    {
        IEnumerable<User> GetAllUsersExeptStaff();
        User GetUserbyId(Guid UserId);
    }
}

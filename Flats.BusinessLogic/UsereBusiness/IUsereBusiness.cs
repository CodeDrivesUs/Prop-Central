using Flats.SharedModel.UserSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.UsereBusiness
{
    public interface IUsereBusiness
    {
        List<UserSharedModel> GetAllUsers();
        UserSharedModel GetUserById(Guid UserId);
    }
}

using AutoMapper;
using Flats.DataMapping.AutoMapper;
using Flats.DataRepository.UsersDataRepository;
using Flats.SharedModel.UserSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.UsersDataMappings
{
    public class UsersDataMappings : IUsersDataMappings
    {
        IMapper mapper = new AutoMapperInit().GetMapperConfig().CreateMapper();
        private IUsersDataRepository _dataRepository;

        public UsersDataMappings()
        {
            _dataRepository = new UsersDataRepository();
        }
        public IEnumerable<UserSharedModel> GetAllUsersExeptStaff()
        {
            var _users = _dataRepository.GetAllUsersExeptStaff();
            return mapper.Map<IEnumerable<UserSharedModel>>(_users);
        }
        public UserSharedModel GetUserbyId(Guid UserId)
        {
            var user = _dataRepository.GetUserbyId(UserId);
            return mapper.Map<UserSharedModel>(user);
        }

    }
}

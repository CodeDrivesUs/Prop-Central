using Flats.SharedModel.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.ProfileBusiness
{
    public interface IProfileBusiness
    {
        void AddProfile(Guid UserId);
        ProfileSharedModel GetFullProfileByUserId(Guid UserId);
        void UpdateProFile(ProfileSharedModel model);
    }
}

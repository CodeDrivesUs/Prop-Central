using Flats.SharedModel.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.ProfileDataMappinigs
{
    public interface IProfileDataMappinigs
    {
        ProfileSharedModel GetFullProfileByUserId(Guid UserId);
        void AddProfilePicture(ProfilePictureSharedModel model);
        void UpdateProfile(ProfileSharedModel model);
    }
}

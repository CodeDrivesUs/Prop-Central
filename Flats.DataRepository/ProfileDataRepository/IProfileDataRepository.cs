using Flats.DataModel.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.ProfileDataRepository
{
    public interface IProfileDataRepository
    {
        void AddProFile(Guid UserId);
        Profile GetFullProfileByUserId(Guid UserId);
        void UpdateProFile(Profile model);
        void AddProFilePicture(ProfilePicture model);
        string GetProfilePicture(Guid profileId);
    }
}

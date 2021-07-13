using Flats.DataMapping.ProfileDataMappinigs;
using Flats.DataRepository.ProfileDataRepository;
using Flats.SharedModel.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.ProfileBusiness
{
    public class ProfileBusiness:IProfileBusiness
    {
        private IProfileDataMappinigs  _profileDataMappinigs;
        private IProfileDataRepository _ProfileDataRepository;
        public ProfileBusiness()
        {
            _profileDataMappinigs = new ProfileDataMappinigs();
            _ProfileDataRepository = new ProfileDataRepository();
        }
        public void AddProfile(Guid UserId)
        {
            _ProfileDataRepository.AddProFile(UserId);
        }
        public  ProfileSharedModel GetFullProfileByUserId(Guid UserId)
        {
            return _profileDataMappinigs.GetFullProfileByUserId(UserId);
        }
        public void UpdateProFile(ProfileSharedModel model)
        {
            _profileDataMappinigs.UpdateProfile(model);         
            if (model.ImageUrl!=null)
            {
                _profileDataMappinigs.AddProfilePicture(new ProfilePictureSharedModel { ImageUrl = model.ImageUrl, ProfileId = model.Id });
            }
        }
       
    }
}

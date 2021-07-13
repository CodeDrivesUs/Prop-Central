using AutoMapper;
using Flats.DataMapping.AutoMapper;
using Flats.DataRepository.ProfileDataRepository;
using Flats.SharedModel.Profile;
using Flats.DataModel.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.ProfileDataMappinigs
{
    public class ProfileDataMappinigs:IProfileDataMappinigs
    {
        IMapper mapper = new AutoMapperInit().GetMapperConfig().CreateMapper();
        private IProfileDataRepository _dataRepository;
        public ProfileDataMappinigs()
        {
            _dataRepository = new ProfileDataRepository();
        }
        public ProfileSharedModel GetFullProfileByUserId(Guid UserId)
        {
            var dbmodel = _dataRepository.GetFullProfileByUserId(UserId);
            return mapper.Map<ProfileSharedModel>(dbmodel);
        }
        public void AddProfilePicture(ProfilePictureSharedModel model)
        {
            _dataRepository.AddProFilePicture(mapper.Map<ProfilePicture>(model));
        }
        public void UpdateProfile(ProfileSharedModel model)
        {
            _dataRepository.UpdateProFile(mapper.Map<DataModel.Profile.Profile>(model));
        }
       
    }
}

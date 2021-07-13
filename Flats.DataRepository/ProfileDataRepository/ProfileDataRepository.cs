using Dapper;
using Flats.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flats.DataModel.Profile;
namespace Flats.DataRepository.ProfileDataRepository
{
    public class ProfileDataRepository:IProfileDataRepository
    {
        private IRepository _repository;

        public ProfileDataRepository()
        {
            _repository = new Repository.Repository();
        }
        public void AddProFile(Guid UserId)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@userId", UserId);       
            _repository.ExecuteNonQuery("AddProfile", sqlParameters, CommandType.StoredProcedure);
        } 
        public void AddProFilePicture(ProfilePicture model)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@profileId", model.ProfileId);       
            sqlParameters.Add("@imageUrl", model.ImageUrl);       
            _repository.ExecuteNonQuery("AddProfilePicture", sqlParameters, CommandType.StoredProcedure);
        }
        public void UpdateProFile(Profile model)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@profileId", model.Id);       
            sqlParameters.Add("@bio", model.Bio);       
            sqlParameters.Add("@homeTown", model.HomeTown);       
            _repository.ExecuteNonQuery("UpdateProfile", sqlParameters, CommandType.StoredProcedure);
        }
        public Profile GetFullProfileByUserId(Guid UserId)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@userId", UserId);
         return _repository.SelectOne<Profile>("GetFullProfileByUserId", sqlParameters, CommandType.StoredProcedure);
        }
        public string GetProfilePicture(Guid profileId)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@profileId", profileId);
         return _repository.SelectOne<string>("GetProfilePicture", sqlParameters, CommandType.StoredProcedure);
        }
        
    }
}

using Dapper;
using Flats.DataModel.Flat;
using Flats.Enums.FlatImagesEnum;
using Flats.Enums.FlatsStatusEnums;
using Flats.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.FlatDataRepository
{
    public class FlatDataRepository : IFlatDataRepository
    {
        private IRepository _repository;


        public FlatDataRepository()
        {
            _repository = new Repository.Repository();
        }
        public void CreateFlat(CreateUpdateFlat createUpdateFlat)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@Name", createUpdateFlat.Name);
            sqlParameters.Add("@PhoneNumber", createUpdateFlat.PhoneNumber);
            sqlParameters.Add("@Address", createUpdateFlat.Address);
            sqlParameters.Add("@Email", createUpdateFlat.Email);
            sqlParameters.Add("@userid", createUpdateFlat.UserId);
            sqlParameters.Add("@statusId", (int)FlatStatusEnum.ApplicationSubmitted);
            sqlParameters.Add("@Rent", createUpdateFlat.RentingPrice);
            sqlParameters.Add("@Deposit", createUpdateFlat.Deposit);
            _repository.ExecuteNonQuery("CreateFlatAndHistory", sqlParameters, CommandType.StoredProcedure);

        }
        public void AcceptFlat(CreateUpdateFlat createUpdateFlat)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@Name", createUpdateFlat.Name);
            sqlParameters.Add("@PhoneNumber", createUpdateFlat.PhoneNumber);
            sqlParameters.Add("@Address", createUpdateFlat.Address);
            sqlParameters.Add("@Email", createUpdateFlat.Email);
            sqlParameters.Add("@userid", createUpdateFlat.UserId);
            sqlParameters.Add("@statusId", (int)FlatStatusEnum.ApplicationAccepted);
            sqlParameters.Add("@Rent", createUpdateFlat.RentingPrice);
            sqlParameters.Add("@Deposit", createUpdateFlat.Deposit);
            sqlParameters.Add("@FlatId", createUpdateFlat.Id);

            _repository.ExecuteNonQuery("AcceptFlatAndHistory", sqlParameters, CommandType.StoredProcedure);

        }
        public void SubmitApplicationForActivation(CreateUpdateFlat createUpdateFlat)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@userid", createUpdateFlat.UserId);
            sqlParameters.Add("@statusId", (int)FlatStatusEnum.ApplicationSubmitedForActivation);
            sqlParameters.Add("@FlatId", createUpdateFlat.Id);
            _repository.ExecuteNonQuery("AccapetPhotosAndHistory", sqlParameters, CommandType.StoredProcedure);
        }
        public void AddRoomOrAmenitie(FlatRoomsAmenities flatRoomsAmenities)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@flatId", flatRoomsAmenities.FlatId);
            sqlParameters.Add("@AmenitieId", flatRoomsAmenities.AmenityId);
            sqlParameters.Add("@RoomTypeId", flatRoomsAmenities.RoomTypeId);
            sqlParameters.Add("@Type", flatRoomsAmenities.Type);
            sqlParameters.Add("@Deposit", flatRoomsAmenities.Deposit);
            sqlParameters.Add("@Rent", flatRoomsAmenities.Rent);
            _repository.ExecuteNonQuery("AddRoomsOrAmenities", sqlParameters, CommandType.StoredProcedure);
        }
      
        public IEnumerable<Flat> GetAllFlatsByStatusId(int statusId)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@statusId", statusId);
            return _repository.Query<Flat>("GetAllFlatsByStatusId", sqlParameters, CommandType.StoredProcedure);
        }
        public IEnumerable<Flat> GetAllFlatsExeptStatusId(int statusId)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@statusId", statusId);
            return _repository.Query<Flat>("GetAllFlatsExeptStatusId", sqlParameters, CommandType.StoredProcedure);
        }
        public IEnumerable<FlatView> GetLatestFlat()
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@statusId", (int)FlatImagesEnum.ProfilePicture);
            return _repository.Query<FlatView>("GetLatestFlats", sqlParameters, CommandType.StoredProcedure);
        }

        public CreateUpdateFlat GetFlatApplication(Guid FlatId)
        {
            var query = string.Format(@"SELECT * FROM  [dbo].[flats] WHERE [Id] = '{0}'", FlatId);
            return _repository.SelectOne<CreateUpdateFlat>(query, null, CommandType.Text);
        }
        public Guid GetApplicantUserId(Guid flatId)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@statusId", (int)FlatStatusEnum.ApplicationSubmitted);
            sqlParameters.Add("@flatId", flatId);
            return _repository.SelectOne<Guid>("GeFlatApplicantUserId", sqlParameters, CommandType.StoredProcedure);
        }
        public void AddToFlatHistory(AddToFlatHistory addToFlatHistory)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@statusId", addToFlatHistory.statusId);
            sqlParameters.Add("@flatId", addToFlatHistory.FlatId);
            sqlParameters.Add("@userId", addToFlatHistory.UserId.ToString());
            _repository.ExecuteNonQuery("AddToFlatHistory", sqlParameters, CommandType.StoredProcedure);
        }
        public void AddLandLord(AddLandLord addLandLord)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@userId", addLandLord.UserId.ToString());
            sqlParameters.Add("@flatId", addLandLord.FlatId);
            _repository.ExecuteNonQuery("AddLandLord", sqlParameters, CommandType.StoredProcedure);
        }
        public IEnumerable<FlatView> GetPaginatedListFlats(int startrow, int rowsperpage, string keyword)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@startRow", startrow);
            sqlParameters.Add("@rowsPerPage", rowsperpage);
            sqlParameters.Add("@isCount", false);
            sqlParameters.Add("@keyword", keyword);
            sqlParameters.Add("@statusId", (int)FlatImagesEnum.ProfilePicture);

            return _repository.Query<FlatView>("GetPaginatedFlats", sqlParameters, CommandType.StoredProcedure);
        }
        public int GetCountPaginatedListFlats( string keyword)
        {
            var sqlParameters = new DynamicParameters();          
            sqlParameters.Add("@isCount", true);
            sqlParameters.Add("@keyword", keyword);
            sqlParameters.Add("@statusId", (int)FlatImagesEnum.ProfilePicture);
            sqlParameters.Add("@startRow", 0);
            sqlParameters.Add("@rowsPerPage", 0);
            return _repository.SelectOne<int>("GetPaginatedFlats", sqlParameters, CommandType.StoredProcedure);
        }
    }
}



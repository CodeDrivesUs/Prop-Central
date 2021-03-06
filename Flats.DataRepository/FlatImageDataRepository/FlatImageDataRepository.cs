using Flats.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flats.DataModel.FlatImages;
using System.Data;
using Flats.Enums.FlatImagesEnum;
using Dapper;

namespace Flats.DataRepository.FlatImageDataRepository
{
    public class FlatImageDataRepository:IFlatImageDataRepository
    {
        private IRepository _repository;


        public FlatImageDataRepository()
        {
            _repository = new Repository.Repository();
        }
        public void AddImage(FlatImages flatImages)
        {
            var query = string.Format(@"INSERT INTO [dbo].[FlatImages]  ([FlatId],[StatusId],[ImageUrl]) VALUES ('{0}','{1}','{2}')", flatImages.FlatId , (int)flatImages.StatusId, flatImages.ImageUrl);
            _repository.ExecuteNonQuery(query, null, CommandType.Text);
        }
        public void AddRoomImage(FlatImages flatImages)
        {
            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("@flatroomtypid", flatImages.FlatRoomtypeId.ToString());
            sqlParameters.Add("@imageUrl", flatImages.ImageUrl);
            sqlParameters.Add("@statusId", (int)FlatImagesEnum.Room);
            _repository.ExecuteNonQuery("AddFlatRoomImage", sqlParameters, CommandType.StoredProcedure);
        }
        public IEnumerable<FlatImages> GetAllImagesForARoom(Guid RoomTypeId)
        {
            var query = string.Format(@"SELECT [Id], [FlatRoomtypeId],[ImageUrl] FROM [dbo].[RoomImages]  WHERE FlatRoomtypeId='{0}' ", RoomTypeId);
            return _repository.Query<FlatImages>(query, null, CommandType.Text);
        }
        public FlatImages GetFlatProfilePicture(Guid FlatId)
        {
            var query = string.Format(@"SELECT [Id], [FlatId],[StatusId],[ImageUrl] FROM [dbo].[FlatImages]  WHERE FlatId='{0}' and StatusId='{1}'", FlatId, (int)FlatImagesEnum.ProfilePicture);
           return _repository.SelectOne<FlatImages>(query, null, CommandType.Text);
        }
        public IEnumerable<FlatImages> GetAllFlatImagesExcludeProfilePicture(Guid FlatId)
        {
            var query = string.Format(@"SELECT [Id], [FlatId],[StatusId],[ImageUrl] FROM [dbo].[FlatImages]  WHERE FlatId='{0}' and StatusId !='{1}'", FlatId, (int)FlatImagesEnum.ProfilePicture);
            return _repository.Query<FlatImages>(query, null, CommandType.Text);
        }
    }
}

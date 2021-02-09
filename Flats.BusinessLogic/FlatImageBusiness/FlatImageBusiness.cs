using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flats.SharedModel.FlatImageSharedModel;
using Flats.DataMapping.FlatImagsDataMappings;
using Flats.BusinessLogic.RoomtypeBusiness;
using Flats.Enums.FlatImagesEnum;

namespace Flats.BusinessLogic.FlatImageBusiness
{
    public class FlatImageBusiness : IFlatImageBusiness
    {
        private IFlatImagsDataMappings _dataMapping;
        private IRoomTypeBusiness _roomTypeBusiness;
        public FlatImageBusiness()
        {
            _roomTypeBusiness = new RoomtypeBusiness.RoomTypeBusiness();
            _dataMapping = new FlatImagsDataMappings();

        }
        public void AddImage(FlatImageSharedModel flatImageSharedModel)
        {
            flatImageSharedModel.StatusId = FlatImagesEnum.Gallery;

            _dataMapping.AddImage(flatImageSharedModel);
        }
        public void AddRoomImage(FlatImageSharedModel flatImageSharedModel)
        {
            _dataMapping.AddRoomImage(flatImageSharedModel);
        }
        public void AddProfilePicture(FlatImageSharedModel flatImageSharedModel)
        {
            flatImageSharedModel.StatusId = FlatImagesEnum.ProfilePicture;
            _dataMapping.AddImage(flatImageSharedModel);
        }
        public FlatImageSharedModel GetProfilePicture(Guid flatId)
        {
            return _dataMapping.GetFlatProfilePicture(flatId);
        }

        public void AddRoomImage(FlatImageSharedModel flatImageSharedModel, string[] ImageUrl)
        {

            Parallel.ForEach(ImageUrl, Image => AddRoomImage(new FlatImageSharedModel
            {
                ImageUrl = Image,
                StatusId = FlatImagesEnum.Room,
                FlatId = flatImageSharedModel.FlatId,
                FlatRoomtypeId = flatImageSharedModel.FlatRoomtypeId
            }));
        }
        public List<FlatImageSharedModel> GetAllFlatImagesExcludeProfilePicture(Guid FlatId)
        {
            return _dataMapping.GetAllFlatImagesExcludeProfilePicture(FlatId).ToList();
        }
        public List<FlatImageSharedModel> GetAllImagesForARoom(Guid RoomtypeId)
        {
            return _dataMapping.GetAllImagesForARoom(RoomtypeId).ToList();
        }
        public List<FlatImageSharedModel> GetGalleryImagesForAFlat(Guid FlatId)
        {
            var _listOfImages = new List<FlatImageSharedModel>();
            Parallel.ForEach(_roomTypeBusiness.GetRoomTypeByFlatId(FlatId), roomtye => _listOfImages.AddRange(GetAllImagesForARoom(roomtye.Id)));
            _listOfImages.AddRange(GetAllFlatImagesExcludeProfilePicture(FlatId));
            return _listOfImages;
        }
    }
}

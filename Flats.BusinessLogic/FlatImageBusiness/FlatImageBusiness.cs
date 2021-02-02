using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flats.SharedModel.FlatImageSharedModel;
using Flats.DataMapping.FlatImagsDataMappings;
using Flats.Enums.FlatImagesEnum;

namespace Flats.BusinessLogic.FlatImageBusiness
{
    public class FlatImageBusiness : IFlatImageBusiness
    {
        private IFlatImagsDataMappings _dataMapping;
        public FlatImageBusiness()
        {
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
    }
}

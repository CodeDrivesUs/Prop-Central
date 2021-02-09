using Flats.SharedModel.FlatImageSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.FlatImagsDataMappings
{
    public interface IFlatImagsDataMappings
    {
        void AddImage(FlatImageSharedModel flatImageSharedModel);
        FlatImageSharedModel GetFlatProfilePicture(Guid FlatId);
        void AddRoomImage(FlatImageSharedModel flatImageSharedModel);
        IEnumerable<FlatImageSharedModel> GetAllImagesForARoom(Guid RoomTypeId);
        IEnumerable<FlatImageSharedModel> GetAllFlatImagesExcludeProfilePicture(Guid FlatId);
    }
}

using Flats.DataModel.FlatImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.FlatImageDataRepository
{
    public interface IFlatImageDataRepository
    {
        void AddImage(FlatImages flatImages);
        FlatImages GetFlatProfilePicture(Guid FlatId);
        void AddRoomImage(FlatImages flatImages);
        IEnumerable<FlatImages> GetAllFlatImagesExcludeProfilePicture(Guid FlatId);
        IEnumerable<FlatImages> GetAllImagesForARoom(Guid RoomTypeId);
    }
}

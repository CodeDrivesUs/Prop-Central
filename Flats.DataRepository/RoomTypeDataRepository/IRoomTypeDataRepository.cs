using Flats.DataModel.RoomType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.RoomTypeDataRepository
{
   public interface IRoomTypeDataRepository
    {
        IEnumerable<RoomType> GetAll();
        IEnumerable<RoomType> GetRoomTypeByFlatId(Guid FlatId);
    }
}

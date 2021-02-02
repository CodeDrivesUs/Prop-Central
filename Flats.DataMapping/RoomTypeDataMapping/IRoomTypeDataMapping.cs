using Flats.SharedModel.RoomTypeSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.RoomTypeDataMapping
{
    public interface IRoomTypeDataMapping
    {
        IEnumerable<RoomTypeSharedModel> GetAll();
        IEnumerable<RoomTypeSharedModel> GetRoomTypeByFlatId(Guid FlatId);
    }
}

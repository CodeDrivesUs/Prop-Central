using Flats.SharedModel.RoomSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.RoomDataMapping
{
    public interface IRoomDataMapping
    {
        void AddRoom(CreateUpdateRoomSharedModel createUpdateRoomSharedModel);
    }
}

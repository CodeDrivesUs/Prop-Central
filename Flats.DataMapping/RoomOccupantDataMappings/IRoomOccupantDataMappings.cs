using Flats.SharedModel.RoomOccupantSharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.RoomOccupantDataMappings
{
    public interface IRoomOccupantDataMappings
    {
        void AddRoomOccupent(RoomOccupantSharedModel roomOccupantSharedModel);
    }
}

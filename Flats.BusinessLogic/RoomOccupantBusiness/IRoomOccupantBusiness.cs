using Flats.SharedModel.RoomOccupantSharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.RoomOccupantBusiness
{
    public interface IRoomOccupantBusiness
    {
        void AddRoomOccupant(RoomOccupantSharedModel roomOccupantSharedModel);
    }
}

using Flats.SharedModel.RoomSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.RoomBusiness
{
    public interface IRoomBusiness
    {
        void AddRoom(CreateUpdateRoomSharedModel createUpdateRoomSharedModel);
    }
}

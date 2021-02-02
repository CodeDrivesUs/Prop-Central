using Flats.SharedModel.RoomTypeSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.RoomtypeBusiness
{
   public  interface IRoomTypeBusiness
    {
        List<RoomTypeSharedModel> GetAllRoomTypes();
        List<RoomTypeSharedModel> GetRoomTypeByFlatId(Guid FlatId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flats.SharedModel.RoomOccupantSharedModels;
using Flats.DataMapping.RoomOccupantDataMappings;

namespace Flats.BusinessLogic.RoomOccupantBusiness
{
    public class RoomOccupantBusiness:IRoomOccupantBusiness
    {
        private  IRoomOccupantDataMappings _dataMapping;
        public RoomOccupantBusiness()
        {
            _dataMapping = new RoomOccupantDataMappings();
        }
        public void AddRoomOccupant(RoomOccupantSharedModel roomOccupantSharedModel)
        {
            _dataMapping.AddRoomOccupent(roomOccupantSharedModel);
        }
    }
}

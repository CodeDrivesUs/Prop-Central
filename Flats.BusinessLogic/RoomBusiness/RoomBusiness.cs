using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flats.SharedModel.RoomSharedModel;
using Flats.DataMapping.RoomDataMapping;

namespace Flats.BusinessLogic.RoomBusiness
{
    public  class RoomBusiness:IRoomBusiness
    {
        private IRoomDataMapping _dataMapping;
        public RoomBusiness()
        {
            _dataMapping = new RoomDataMapping();
        }
        public void AddRoom(CreateUpdateRoomSharedModel createUpdateRoomSharedModel)
        {
            _dataMapping.AddRoom(createUpdateRoomSharedModel);
        }
    }
}

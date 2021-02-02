using Flats.DataMapping.RoomTypeDataMapping;
using Flats.SharedModel.RoomTypeSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.RoomtypeBusiness
{
    public class RoomTypeBusiness:IRoomTypeBusiness
    {
        private IRoomTypeDataMapping _dataMapping;

        public RoomTypeBusiness()
        {
            _dataMapping = new RoomTypeDataMapping();
        }
        public List<RoomTypeSharedModel> GetAllRoomTypes()
        {
            return _dataMapping.GetAll().ToList();
        }
        public List<RoomTypeSharedModel> GetRoomTypeByFlatId(Guid FlatId)
        {
            return _dataMapping.GetRoomTypeByFlatId(FlatId).ToList();
        }
    }
}

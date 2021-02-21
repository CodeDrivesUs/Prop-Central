using Flats.Enums.GenderEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Flats.SharedModel.RoomSharedModel
{
    public class CreateUpdateRoomSharedModel:BasePrimaryKey
    {
        public Guid FlatId { get; set; }
        public Guid RoomTypeId { get; set; }
        public string RoomNumber { get; set; }
        public GenderEnum Gender { get; set; }
        public List<RoomTypeSharedModel.RoomTypeSharedModel> listRoomTypes { get; set; }
        
    }
}

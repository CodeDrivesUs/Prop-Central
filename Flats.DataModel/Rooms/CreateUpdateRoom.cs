using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flats.Enums.GenderEnum;
namespace Flats.DataModel.Rooms
{
    public class CreateUpdateRoom:BasePrimaryKey
    {
        public Guid FlatId { get; set; }
        public Guid RoomTypeId { get; set; }
        public GenderEnum Gender  { get; set; }
        public string RoomNumber { get; set; }
    }
}

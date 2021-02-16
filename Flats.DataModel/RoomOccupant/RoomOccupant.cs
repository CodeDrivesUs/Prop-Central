using Flats.Enums.GenderEnum;
using Flats.Enums.RoomOccupentEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataModel.RoomOccupant
{
    public class RoomOccupant:BasePrimaryKey
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public RoomOccupentEnums StatusId { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

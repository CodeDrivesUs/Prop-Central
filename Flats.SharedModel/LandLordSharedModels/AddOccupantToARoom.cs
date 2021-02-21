using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Flats.SharedModel.LandLordSharedModels
{
    public class AddOccupantToARoom
    {
        public RoomOccupantSharedModels.RoomOccupantSharedModel RoomOccupantSharedModel   { get; set; }
        public Guid bookingId  { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.LandLordSharedModels
{
    public class LandLordIndex
    {
        public FlatSharedModels.CreateUpdateFlatSharedModel _flat { get; set; }
        public string ProfilePicture { get; set; }
        public List<RoomBookingSharedModel.UserRoomBooingSharedModel> _flatBookings { get; set; }
    }
}

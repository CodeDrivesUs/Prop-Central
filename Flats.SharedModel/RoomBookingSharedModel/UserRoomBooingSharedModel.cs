using Flats.Enums.GenderEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.RoomBookingSharedModel
{
    public class UserRoomBooingSharedModel:BasePrimaryKey
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public Guid UseriId { get; set; }
        public Guid RoomTypeId { get; set; }
        public Guid FlatId { get; set; }
        public DateTime BookingCreationDate { get; set; }
        public string IdNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


    }
}

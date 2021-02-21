using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flats.SharedModel.AmenitiesSharedModel;

namespace Flats.SharedModel.FlatSharedModels
{
    public class FullFlatApplicationSharedModel
    {
        public Guid UserId { get; set; }
        public string FlatName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public decimal Rent { get; set; }
        public decimal Deposit { get; set; }
        public Guid[] Amenities { get; set; }
        public Guid[] RoomTypes { get; set; }
        public string[] RentWithIds { get; set; }
        public string[] DepositWithIds { get; set; }
        public List<FlatRoomTypesSharedModel> _listflatroomtypes { get; set; }
        public List<AmenitiesSharedModel.AmenitiesSharedModel> _listamenities { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Flats.SharedModel.FlatSharedModels;
using System.Threading.Tasks;

namespace Flats.SharedModel.FlatSharedModels
{
   public  class CreateUpdateFlatSharedModel:BasePrimaryKey
    {
        [Display(Name = "Flat Name")]
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Renting Price")]
        public decimal RentingPrice { get; set; }
        [Display(Name = "Deposite Price")]

        public decimal Deposit { get; set; }
        public int Status { get; set; }
      
        [Display(Name = "Flat PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Flat Email")]
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public List<Flats.SharedModel.AmenitiesSharedModel.AmenitiesSharedModel> ListAmenities { get; set; }
        public List<Flats.SharedModel.RoomTypeSharedModel.RoomTypeSharedModel> ListRoomTypes { get; set; }
    }
}

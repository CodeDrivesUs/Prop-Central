using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.FlatSharedModels
{
    public class FlatViewModel : BaseImageUrl
    {
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Renting Price")]
        public decimal RentingPrice { get; set; }
        [Display(Name = "Deposite Price")]

        public decimal Deposit { get; set; }
        public string Email { get; set; }

        public DateTime Date { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string ShortDescription { get; set; }

    }
}

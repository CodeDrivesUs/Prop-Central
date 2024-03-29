﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataModel.Flat
{
   public  class CreateUpdateFlat:BasePrimaryKey
    {
      
        public string Name { get; set; }
    
        public string Address { get; set; }
    
        public decimal RentingPrice { get; set; }

        public decimal Deposit { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataModel.Flat
{
    public  class FlatView:BasePrimaryKey
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal RentingPrice { get; set; }

        public decimal Deposit { get; set; }
    }
}

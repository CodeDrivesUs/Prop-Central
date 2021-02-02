using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataModel.Amenities
{
  public  class Amenities:BasePrimaryKey
    { 
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}

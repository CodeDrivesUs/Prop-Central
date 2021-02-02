using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataModel.Flat
{
    public class AddToFlatHistory
    {
        public Guid FlatId { get; set; }
        public Guid UserId { get; set; }

        public int  statusId { get; set; }
    }
}

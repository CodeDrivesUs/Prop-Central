using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.HomeSharedModel
{
    public class FindFlatSharedModel
    {
        public List<RoomTypeSharedModel.RoomTypeSharedModel> RoomTypes { get; set; }

        public string Keyword { get; set; }
    }
}

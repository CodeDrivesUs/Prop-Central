using Flats.SharedModel.FlatSharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.HomeSharedModel
{
    public  class HomeSharedmodel
    {
        public List<RoomTypeSharedModel.RoomTypeSharedModel> RoomTypes { get; set; }
        public List<FlatViewModel> LatestFlats { get; set; }

    }
}

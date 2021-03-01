using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.CamaraSharedModels
{
    public class FlatDashboard
    {
        public FlatImageSharedModel.FlatImageSharedModel ProfilePicture { get; set; }
        public FlatSharedModels.CreateUpdateFlatSharedModel flat { get; set; }
        public List<FlatSharedModels.FlatRoomTypesSharedModel> roomtypes { get; set; }
    }
}

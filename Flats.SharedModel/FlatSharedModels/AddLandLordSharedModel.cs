using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.FlatSharedModels
{
    public class AddLandLordSharedModel
    {
        public UserSharedModel.UserSharedModel  userSharedModel { get; set; }
        public Guid FlatId { get; set; }
        public Guid UserId { get; set; }
        public Guid AdminId { get; set; }
    }
}

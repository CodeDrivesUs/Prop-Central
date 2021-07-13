using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataModel.Profile
{
    public class ProfilePicture:BasePrimaryKey
    {
        public Guid ProfileId { get; set; }
        public DateTime DateAdded { get; set; }
        public string ImageUrl { get; set; }
    }
}

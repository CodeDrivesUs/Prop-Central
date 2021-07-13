using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.Profile
{
    public class ProfilePictureSharedModel:BaseImageUrl
    {
        public Guid ProfileId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

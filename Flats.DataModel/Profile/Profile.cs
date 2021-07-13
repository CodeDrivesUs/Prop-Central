using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataModel.Profile
{
    public class Profile:BasePrimaryKey
    {
        public Guid UserId { get; set; }
        public string Bio { get; set; }
        public Guid ProfilePictureId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HomeTown { get; set; }
        public string ImageUrl { get; set; }
    }
}

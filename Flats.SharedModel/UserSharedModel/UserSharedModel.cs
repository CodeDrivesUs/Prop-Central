using Flats.Enums.GenderEnum;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.UserSharedModel
{

        public class UserSharedModel : IdentityUser
        {
            public string FirstName { get; internal set; }
            public string LastName { get; internal set; }
            public GenderEnum Gender { get; internal set; }
        }
}

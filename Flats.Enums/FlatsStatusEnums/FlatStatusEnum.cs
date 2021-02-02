using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Flats.Enums.FlatsStatusEnums
{
    public enum FlatStatusEnum
    {     
        ApplicationSubmitted =1,
        ApplicationAccepted=2,
        AddLandLord=3,
        ApplicationSubmitedForActivation=4
    }
}

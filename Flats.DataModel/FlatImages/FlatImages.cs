using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flats.Enums.FlatImagesEnum;

namespace Flats.DataModel.FlatImages
{
    public class FlatImages:BasePrimaryKey
    {
        public Guid FlatId { get; set; }
        public Guid FlatRoomtypeId { get; set; }
        public FlatImagesEnum StatusId { get; set; }
        public string ImageUrl { get; set; }
    }
}

using Flats.Enums.FlatImagesEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.FlatImageSharedModel
{
    public class FlatImageSharedModel:BaseImageUrl
    {
        public Guid FlatId { get; set; }
        public Guid FlatRoomtypeId { get; set; }

        public FlatImagesEnum StatusId { get; set; }
    }
}

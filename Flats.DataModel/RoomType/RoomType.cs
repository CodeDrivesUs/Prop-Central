using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataModel.RoomType
{
    public class RoomType:BasePrimaryKey
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPeople { get; set; }

    }
}

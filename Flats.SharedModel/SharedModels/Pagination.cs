using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.SharedModels
{
    public class Pagination
    {
        public int _from { get; set; }
        public int _to { get; set; }
        public int _current { get; set; }
        public int _final { get; set; }
        public int _count { get; set; }
    }
}

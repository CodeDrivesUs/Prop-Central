using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.HomeSharedModel
{
    public class FlatSharedModel
    {
        public FlatSharedModels.CreateUpdateFlatSharedModel _flat { get; set; }
        public string ProfilePicture { get; set; }
        public List<FlatImageSharedModel.FlatImageSharedModel> AllPictures { get; set; }
    }
}

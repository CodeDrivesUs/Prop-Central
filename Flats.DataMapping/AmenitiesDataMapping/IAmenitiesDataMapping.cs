using Flats.SharedModel.AmenitiesSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.AmenitiesDataMapping
{
   public  interface IAmenitiesDataMapping
    {
        IEnumerable<AmenitiesSharedModel> GetAll();

        void Add(AmenitiesSharedModel model);

        void Delete(int id);
        AmenitiesSharedModel Get(int id);
        void Update(AmenitiesSharedModel model);
        IEnumerable<AmenitiesSharedModel> GetAmenitiesByFlatId( Guid FlatId);
    }
}

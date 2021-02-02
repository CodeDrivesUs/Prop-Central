using Flats.SharedModel.AmenitiesSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.AmenitiesBusiness
{
   public  interface IAmenitiesBusiness
    {
        void Add(AmenitiesSharedModel model);
        List<AmenitiesSharedModel> GetAll();
        void Delete(int id);
        AmenitiesSharedModel Get(int id);
        void Update(AmenitiesSharedModel model);
    }
}

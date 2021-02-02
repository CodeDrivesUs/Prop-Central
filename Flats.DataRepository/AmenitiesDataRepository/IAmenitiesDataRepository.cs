using Flats.DataModel.Amenities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.AmenitiesDataRepository
{
  public  interface IAmenitiesDataRepository
    {
        IEnumerable<Amenities> GetAll();

        void Add(Amenities model);

        void Delete(int id);
        void Update(Amenities model);
        Amenities Get(int id);
    }
}

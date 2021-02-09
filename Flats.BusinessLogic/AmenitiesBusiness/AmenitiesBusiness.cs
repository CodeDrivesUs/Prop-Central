using Flats.DataMapping.AmenitiesDataMapping;
using Flats.SharedModel.AmenitiesSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.AmenitiesBusiness
{
    public class AmenitiesBusiness : IAmenitiesBusiness
    {
        private IAmenitiesDataMapping _dataMapping;

        public AmenitiesBusiness()
        {
            _dataMapping = new AmenitiesDataMapping();
        }
        public void Add(AmenitiesSharedModel model)
        {
             _dataMapping.Add(model);
        }

        public void Delete(int id)
        {
             _dataMapping.Delete(id);
        }

        public AmenitiesSharedModel Get(int id)
        {
            return _dataMapping.Get(id);
        }

        public List<AmenitiesSharedModel> GetAll()
        {
            return (List<AmenitiesSharedModel>)_dataMapping.GetAll();
        }
        public List<AmenitiesSharedModel> GetAmenitiesByFlatId(Guid FlatId)
        {
            return (List<AmenitiesSharedModel>)_dataMapping.GetAmenitiesByFlatId(FlatId);
        }

        public void Update(AmenitiesSharedModel model)
        {
            _dataMapping.Update(model);
        }
    }
}

﻿using AutoMapper;
using Flats.DataMapping.AutoMapper;
using Flats.DataModel.Amenities;
using Flats.DataRepository.AmenitiesDataRepository;
using Flats.SharedModel.AmenitiesSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.AmenitiesDataMapping
{
   public class AmenitiesDataMapping:IAmenitiesDataMapping
    {
        IMapper mapper = new AutoMapperInit().GetMapperConfig().CreateMapper();
        private IAmenitiesDataRepository _dataRepository;

        public AmenitiesDataMapping()
        {
            _dataRepository = new AmenitiesDataRepository();
        }

     
        public void Add(AmenitiesSharedModel model)
        {
            var dbModel = mapper.Map<Amenities>(model);
            _dataRepository.Add(dbModel);
        }
        public void Update(AmenitiesSharedModel model)
        {
            var dbModel = mapper.Map<Amenities>(model);
            _dataRepository.Update(dbModel);
        }
        public void Delete(int id)
        {
            _dataRepository.Delete(id);
        }

        public AmenitiesSharedModel Get(int id)
        {
            var store = _dataRepository.Get(id);
            return mapper.Map<AmenitiesSharedModel>(store);
        }

        public IEnumerable<AmenitiesSharedModel> GetAll()
        {
            var stores = _dataRepository.GetAll();
            return mapper.Map<IEnumerable<AmenitiesSharedModel>>(stores);
        }
    }
}

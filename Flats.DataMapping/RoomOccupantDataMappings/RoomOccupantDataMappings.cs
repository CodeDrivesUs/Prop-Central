using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flats.DataRepository.RoomOccupantDataRepository;
using Flats.DataModel.RoomOccupant;
using AutoMapper;
using Flats.DataMapping.AutoMapper;
using Flats.SharedModel.RoomOccupantSharedModels;

namespace Flats.DataMapping.RoomOccupantDataMappings
{
    public  class RoomOccupantDataMappings:IRoomOccupantDataMappings
    {
        IMapper mapper = new AutoMapperInit().GetMapperConfig().CreateMapper();
        private IRoomOccupantDataRepository  _dataRepository;
        public RoomOccupantDataMappings()
        {
            _dataRepository = new RoomOccupantDataRepository();
        }

        public void AddRoomOccupent( RoomOccupantSharedModel roomOccupantSharedModel)
        {
            var dbModel = mapper.Map<RoomOccupant>(roomOccupantSharedModel);
            _dataRepository.AddRoomOccupant(dbModel);
        }

    }
}

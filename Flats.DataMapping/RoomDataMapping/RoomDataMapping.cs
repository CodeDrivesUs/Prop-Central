using AutoMapper;
using Flats.DataMapping.AutoMapper;
using Flats.DataRepository.RoomDataRepository;
using Flats.DataModel.Rooms;
using Flats.SharedModel.RoomSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.RoomDataMapping
{
    public  class RoomDataMapping:IRoomDataMapping
    {
        IMapper mapper = new AutoMapperInit().GetMapperConfig().CreateMapper();
        private IRoomDataRepository _dataRepository;
        public RoomDataMapping()
        {
            _dataRepository = new RoomDataRepository();
        }
        public void AddRoom(CreateUpdateRoomSharedModel createUpdateRoomSharedModel)
        {
            var dbModel = mapper.Map<CreateUpdateRoom>(createUpdateRoomSharedModel);
            _dataRepository.AddRoom(dbModel);
        }
    }
}

using AutoMapper;
using Flats.DataMapping.AutoMapper;
using Flats.DataRepository.RoomTypeDataRepository;
using Flats.SharedModel.RoomTypeSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.RoomTypeDataMapping
{
    public class RoomTypeDataMapping:IRoomTypeDataMapping
    {
        IMapper mapper = new AutoMapperInit().GetMapperConfig().CreateMapper();
        private IRoomTypeDataRepository _dataRepository;

        public RoomTypeDataMapping()
        {
            _dataRepository = new RoomTypeDataRepository();
        }

        public IEnumerable<RoomTypeSharedModel> GetAll()
        {
            var roomtype = _dataRepository.GetAll();
            return mapper.Map<IEnumerable<RoomTypeSharedModel>>(roomtype);
        }
        public IEnumerable<RoomTypeSharedModel> GetRoomTypeByFlatId(Guid FlatId)
        {
            var roomtype = _dataRepository.GetRoomTypeByFlatId(FlatId);
            return mapper.Map<IEnumerable<RoomTypeSharedModel>>(roomtype);
        }
    }
}

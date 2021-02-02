using Flats.DataModel.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.RoomDataRepository
{
    public interface IRoomDataRepository
    {
        void AddRoom(CreateUpdateRoom createUpdateRoom);
    }
}

using Flats.DataModel.RoomOccupant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.RoomOccupantDataRepository
{
    public interface IRoomOccupantDataRepository
    {
        Guid AddRoomOccupant(RoomOccupant roomOccupant);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.FlatSharedModels
{
    public class FlatRoomTypesSharedModel:BasePrimaryKey
    {
        public string Name { get; set; }
        public Guid RoomTypeId { get; set; }
        public string Description { get; set; }
        public int NumberOfPeople { get; set; }
        public decimal Deposit { get; set; }
        public decimal Rent { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel.RoomTypeSharedModel
{
  public  class RoomTypeSharedModel:BasePrimaryKey
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPeople { get; set; }

    }
}

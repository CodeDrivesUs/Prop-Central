using AutoMapper;
using Flats.DataModel.Amenities;
using Flats.DataModel.Flat;
using Flats.DataModel.RoomType;
using Flats.DataModel.Users;
using Flats.DataModel.Rooms;
using Flats.DataModel.FlatImages;
using Flats.DataModel.RoomBookings;
using Flats.DataModel.RoomOccupant;
using Flats.SharedModel;
using Flats.SharedModel.AmenitiesSharedModel;
using Flats.SharedModel.FlatSharedModels;
using Flats.SharedModel.RoomTypeSharedModel;
using Flats.SharedModel.UserSharedModel;
using Flats.SharedModel.RoomSharedModel;
using Flats.SharedModel.FlatImageSharedModel;
using Flats.SharedModel.RoomBookingSharedModel;
using Flats.SharedModel.RoomOccupantSharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.AutoMapper
{
    class AutoMapperProfileConfig: Profile
    {
        public AutoMapperProfileConfig()
        {
            CreateMap<AmenitiesSharedModel, Amenities>().ReverseMap();
            CreateMap<CreateUpdateFlatSharedModel, CreateUpdateFlat>().ReverseMap();
            CreateMap<FlatSharedModel,Flat>().ReverseMap();
            CreateMap<FlatAmenitiesRoomsModel, FlatRoomsAmenities>().ReverseMap();
            CreateMap<RoomTypeSharedModel, RoomType>().ReverseMap();
            CreateMap<UserSharedModel, User>().ReverseMap();            
            CreateMap<AddLandLordSharedModel, AddLandLord>().ReverseMap();
            CreateMap<AddToFlatHistorySharedModel, AddToFlatHistory>().ReverseMap();
            CreateMap<CreateUpdateRoomSharedModel, CreateUpdateRoom>().ReverseMap();
            CreateMap<FlatImageSharedModel, FlatImages>().ReverseMap();
            CreateMap<FlatViewModel, FlatView>().ReverseMap();
            CreateMap<RoomBookingSharedModel, RoomBooking>().ReverseMap();
            CreateMap<UserRoomBooingSharedModel, UserRoomBooking>().ReverseMap();
            CreateMap<RoomOccupantSharedModel, RoomOccupant>().ReverseMap();
            CreateMap<RoomOccupantSharedModel, UserRoomBooking>().ReverseMap();
            CreateMap<FlatRoomTypesSharedModel, FlatRoomTypes>().ReverseMap();

        }
    }
}

using Flats.DataMapping.FlatDataMappings;
using Flats.Enums.FlatsStatusEnums;
using Flats.SharedModel;
using Flats.SharedModel.FlatSharedModels;
using Flats.BusinessLogic.AmenitiesBusiness;
using Flats.BusinessLogic.RoomtypeBusiness;
using Flats.SharedModel.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.FlatBusiness
{
    public class FlatBusiness:IFlatBusiness
    {

        private IFlatDataMapping _dataMapping;
        private IAmenitiesBusiness _amenitiesBusiness;
        private IRoomTypeBusiness _roomTypeBusiness;
        private int rowsperpage = 9;


        public FlatBusiness()
        {
            _dataMapping = new FlatDataMapping();
            _amenitiesBusiness = new AmenitiesBusiness.AmenitiesBusiness();
            _roomTypeBusiness = new RoomtypeBusiness.RoomTypeBusiness();
        }
        public void Add(CreateUpdateFlatSharedModel model)
        {
            _dataMapping.CreateFlat(model);
        }

        public List<FlatSharedModel> GetAllSubmittedApllications()
        {
            return _dataMapping.GetAllFlatsByStatusId((int)FlatStatusEnum.ApplicationSubmitted).ToList();
        }

        public List<FlatSharedModel> GetAllApprovedApllications()
        {
            return _dataMapping.GetAllFlatsByStatusId((int)FlatStatusEnum.ApplicationAccepted).ToList();
        }
        public List<FlatSharedModel> GetFlatsToAddRooms()
        {
            return _dataMapping.GetAllFlatsExeptStatusId((int)FlatStatusEnum.ApplicationSubmitted).ToList();
        }
        public void AddFlatRoomType( Guid flatId, Guid roomtypeId)
        {
            _dataMapping.AddRoomOrAmenitie(new FlatAmenitiesRoomsModel { RoomTypeId = roomtypeId, FlatId = flatId, Type = 2 });
        }
        public void AddAmenitie(Guid flatId, Guid  amenityId)
        {
            _dataMapping.AddRoomOrAmenitie(new FlatAmenitiesRoomsModel { FlatId= flatId, AmenityId= amenityId, Type = 1 });
        }

        public CreateUpdateFlatSharedModel GetFlatApplication(Guid FlatId)
        {
            return _dataMapping.GetFlatApplication(FlatId);
        }
        public void ProcessApplication(CreateUpdateFlatSharedModel createUpdateFlatSharedModel, Guid[] Amenities, Guid[] RoomTypes)
        {
            
            Parallel.ForEach(Amenities, amenity => AddAmenitie(createUpdateFlatSharedModel.Id, amenity));
            Parallel.ForEach(RoomTypes, roomtype=>AddFlatRoomType(createUpdateFlatSharedModel.Id,roomtype));
            _dataMapping.AcceptFlat(createUpdateFlatSharedModel);
        }
        public void SubmitApplicationForActivation(CreateUpdateFlatSharedModel createUpdateFlatSharedModel)
        {
            createUpdateFlatSharedModel.Status = (int)FlatStatusEnum.ApplicationSubmitted;
            _dataMapping.SubmitApplicationForActivation(createUpdateFlatSharedModel);
        }
        public Guid GetApplicantUserId(Guid FlatId)
        {
            return _dataMapping.GetApplicantUserId(FlatId);
        }
        public void AddLandLord(AddLandLordSharedModel addLandLord)
        {
            _dataMapping.AddLandLord(addLandLord);
            AddToFlatHistory(addLandLord.FlatId, addLandLord.UserId, (int)FlatStatusEnum.AddLandLord);   
        }

        public void AddToFlatHistory(Guid FlatId, Guid UserId, int status)
        {
            _dataMapping.AddToFlatHistory(new AddToFlatHistorySharedModel { FlatId=FlatId, statusId=status, UserId=UserId });
        }
        public List<FlatViewModel> GetPaginatedListFlats(int page, string keyword)
        {
            return _dataMapping.GetPaginatedListFlats(GetStartRow(page), rowsperpage, keyword).ToList();
        }
        public List<FlatViewModel> GetLatestFlats()
        {
            return _dataMapping.GetLatestFlat().ToList();
        }
        public int GetStartRow(int page)
        {
            int capture = page - 1;
            if (page == 1)
            {
                return 0;
            }
            return capture * rowsperpage;
        }
        public int CalcTotalPages(string Keyword )
        {
            int totalnews = _dataMapping.GetCountPaginatedListFlats(Keyword);
            int valu = totalnews / rowsperpage;
            int modulas = totalnews % rowsperpage;
            if (modulas != 0)
            {
                ++valu;
            }
            return valu;
        }
        public Pagination PopulatePagination( string keyword ,int page)
        {
            int total = GetPaginatedListFlats(page,keyword).ToList().Count;
            int _to = GetStartRow(page) + total;
            int _from = GetStartRow(page) + 1;
            return new Pagination { _count=_dataMapping.GetCountPaginatedListFlats(keyword), _current=page, _final=CalcTotalPages(keyword), _from=_from, _to= _to };
        }
        public CreateUpdateFlatSharedModel GetFlatPopulatedWithRommtypesAndAmenities(Guid FlatId)
        {
            var model = GetFlatApplication(FlatId);
            model.ListAmenities = _amenitiesBusiness.GetAmenitiesByFlatId(FlatId);
            model.ListRoomTypes = _roomTypeBusiness.GetRoomTypeByFlatId(FlatId);
            return model;
        }
        public int GetCountPaginatedListFlats( string keyword)
        {
            return _dataMapping.GetCountPaginatedListFlats(keyword);
        }




    }
}

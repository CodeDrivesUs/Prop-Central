using Flats.DataMapping.FlatDataMappings;
using Flats.Enums.FlatsStatusEnums;
using Flats.SharedModel;
using Flats.SharedModel.FlatSharedModels;
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

        public FlatBusiness()
        {
            _dataMapping = new FlatDataMapping();
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
        public List<FlatViewModel> GetLatestFlats()
        {
            return _dataMapping.GetLatestNews().ToList();
        }
    }
}

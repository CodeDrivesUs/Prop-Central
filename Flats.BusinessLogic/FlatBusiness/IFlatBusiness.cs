using Flats.SharedModel;
using Flats.SharedModel.FlatSharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.FlatBusiness
{
    public interface IFlatBusiness
    {
        void Add(CreateUpdateFlatSharedModel model);
        List<FlatSharedModel> GetAllSubmittedApllications();
        CreateUpdateFlatSharedModel GetFlatApplication(Guid FlatId);
        List<FlatSharedModel> GetAllApprovedApllications();
        void AddAmenitie(Guid flatId, Guid amenityId);
        void AddFlatRoomType(Guid flatId, Guid roomtypeId);
        void ProcessApplication(CreateUpdateFlatSharedModel createUpdateFlatSharedModel, Guid[] Amenities, Guid[] RoomTypes);
        Guid GetApplicantUserId(Guid FlatId);
        void AddLandLord(AddLandLordSharedModel addLandLord);
        List<FlatSharedModel> GetFlatsToAddRooms();
        void SubmitApplicationForActivation(CreateUpdateFlatSharedModel createUpdateFlatSharedModel);
        List<FlatViewModel> GetLatestFlats();
    }
}

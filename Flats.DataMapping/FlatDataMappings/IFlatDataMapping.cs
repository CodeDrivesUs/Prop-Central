using Flats.SharedModel;
using Flats.SharedModel.FlatSharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.FlatDataMappings
{
  public interface IFlatDataMapping
    {
        void CreateFlat(CreateUpdateFlatSharedModel createUpdateFlat);
        IEnumerable<FlatSharedModel> GetAllFlatsByStatusId(int statusId);
        void AddRoomOrAmenitie(FlatAmenitiesRoomsModel flatAmenitiesRoomsModel);
        CreateUpdateFlatSharedModel GetFlatApplication(Guid FlatId);
        void AcceptFlat(CreateUpdateFlatSharedModel createUpdateFlat);
        Guid GetApplicantUserId(Guid FlatId);
        void AddLandLord(AddLandLordSharedModel addLandLord);
        void AddToFlatHistory(AddToFlatHistorySharedModel addToFlatHistory);
        IEnumerable<FlatSharedModel> GetAllFlatsExeptStatusId(int statusId);
        void SubmitApplicationForActivation(CreateUpdateFlatSharedModel createUpdateFlat);
        IEnumerable<FlatViewModel> GetLatestNews();
    }
}

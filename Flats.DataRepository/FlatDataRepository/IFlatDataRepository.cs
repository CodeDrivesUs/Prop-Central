using Flats.DataModel.Flat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.FlatDataRepository
{
    public interface IFlatDataRepository
    {
        Guid CreateFlat(CreateUpdateFlat createUpdateFlat);
        
        IEnumerable<Flat> GetAllFlatsExeptStatusId(int statusId);
        IEnumerable<Flat> GetAllFlatsByStatusId(int statusId);

        void AddRoomOrAmenitie(FlatRoomsAmenities flatRoomsAmenities);
        CreateUpdateFlat GetFlatApplication(Guid FlatId);
        void AcceptFlat(CreateUpdateFlat createUpdateFlat);
        void AddLandLord(AddLandLord addLandLord);
        Guid GetApplicantUserId(Guid flatId);
        void AddToFlatHistory(AddToFlatHistory addToFlatHistory);
        void SubmitApplicationForActivation(CreateUpdateFlat createUpdateFlat);
        IEnumerable<FlatView> GetLatestFlat();
        IEnumerable<FlatView> GetPaginatedListFlats(int startrow, int rowsperpage, string keyword);
        int GetCountPaginatedListFlats(string keyword);
        IEnumerable<FlatRoomTypes> GetFlatRoomTypesByFlatId(Guid FlatId);
        IEnumerable<CreateUpdateFlat> GetUserFlatListByStatusId(Guid UserId, int statusId);
        IEnumerable<CreateUpdateFlat> GetAllUserFlatList(Guid UserId, int statusId);
    }
}

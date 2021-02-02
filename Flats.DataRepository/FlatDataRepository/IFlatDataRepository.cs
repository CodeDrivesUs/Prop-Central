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
        void CreateFlat(CreateUpdateFlat createUpdateFlat);
        
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
    }
}

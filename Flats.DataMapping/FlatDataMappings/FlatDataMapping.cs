using AutoMapper;
using Flats.DataMapping.AutoMapper;
using Flats.DataModel.Flat;
using Flats.DataRepository.FlatDataRepository;
using Flats.SharedModel;
using Flats.SharedModel.FlatSharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.FlatDataMappings
{
    public class FlatDataMapping : IFlatDataMapping
    {
        IMapper mapper = new AutoMapperInit().GetMapperConfig().CreateMapper();
        private IFlatDataRepository _dataRepository;

        public FlatDataMapping()
        {
            _dataRepository = new FlatDataRepository();
        }
        public void CreateFlat(CreateUpdateFlatSharedModel createUpdateFlat)
        {
            var dbModel = mapper.Map<CreateUpdateFlat>(createUpdateFlat);
            _dataRepository.CreateFlat(dbModel);
        }
        
        public void AcceptFlat(CreateUpdateFlatSharedModel createUpdateFlat)
        {
            var dbModel = mapper.Map<CreateUpdateFlat>(createUpdateFlat);
            _dataRepository.AcceptFlat(dbModel);
        }
        public void SubmitApplicationForActivation(CreateUpdateFlatSharedModel createUpdateFlat)
        {
            var dbModel = mapper.Map<CreateUpdateFlat>(createUpdateFlat);
            _dataRepository.SubmitApplicationForActivation(dbModel);
        }
        public IEnumerable<FlatSharedModel> GetAllFlatsByStatusId(int statusId)
        {
            var dbModel = _dataRepository.GetAllFlatsByStatusId(statusId);
            return mapper.Map<IEnumerable<FlatSharedModel>>(dbModel);
        }
        public IEnumerable<FlatViewModel> GetLatestNews()
        {
            var dbModel= _dataRepository.GetLatestFlat();
            return mapper.Map<IEnumerable<FlatViewModel>>(dbModel);
        }
        public IEnumerable<FlatSharedModel> GetAllFlatsExeptStatusId(int statusId)
        {
            var dbModel = _dataRepository.GetAllFlatsExeptStatusId(statusId);
            return mapper.Map<IEnumerable<FlatSharedModel>>(dbModel);
        }
        public void AddRoomOrAmenitie( FlatAmenitiesRoomsModel flatAmenitiesRoomsModel)
        {
            var dbModel = mapper.Map<FlatRoomsAmenities>(flatAmenitiesRoomsModel);
            _dataRepository.AddRoomOrAmenitie(dbModel);
        }
        public void AddLandLord(AddLandLordSharedModel addLandLord)
        {
            var dbModel = mapper.Map<AddLandLord>(addLandLord);
            _dataRepository.AddLandLord(dbModel);
        }
        public void AddToFlatHistory(AddToFlatHistorySharedModel addToFlatHistory)
        {
            var dbModel = mapper.Map<AddToFlatHistory>(addToFlatHistory);
            _dataRepository.AddToFlatHistory(dbModel);
        }
        public CreateUpdateFlatSharedModel GetFlatApplication(Guid FlatId)
        {
            var flatApplication = _dataRepository.GetFlatApplication(FlatId);
            return mapper.Map<CreateUpdateFlatSharedModel>(flatApplication);
        }
        public Guid GetApplicantUserId(Guid FlatId)
        {
            return _dataRepository.GetApplicantUserId(FlatId);
        }
      
    }
}

using AutoMapper;
using Flats.DataMapping.AutoMapper;
using Flats.DataRepository.FlatImageDataRepository;
using Flats.SharedModel.FlatImageSharedModel;
using Flats.DataModel.FlatImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataMapping.FlatImagsDataMappings
{
    public class FlatImagsDataMappings:IFlatImagsDataMappings
    {
        IMapper mapper = new AutoMapperInit().GetMapperConfig().CreateMapper();
        private IFlatImageDataRepository  _dataRepository;

        public FlatImagsDataMappings()
        {
            _dataRepository = new FlatImageDataRepository();
        }
        public void AddImage( FlatImageSharedModel flatImageSharedModel)
        {
            var dbModel = mapper.Map<FlatImages>(flatImageSharedModel);
            _dataRepository.AddImage(dbModel);
        }
        public void AddRoomImage(FlatImageSharedModel flatImageSharedModel)
        {
            var dbModel = mapper.Map<FlatImages>(flatImageSharedModel);
            _dataRepository.AddRoomImage(dbModel);
        }
        public FlatImageSharedModel GetFlatProfilePicture( Guid FlatId)
        {
            return mapper.Map<FlatImageSharedModel>(_dataRepository.GetFlatProfilePicture(FlatId));
        }

    }
}

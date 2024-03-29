﻿using Flats.SharedModel;
using Flats.SharedModel.FlatSharedModels;
using Flats.SharedModel.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.FlatBusiness
{
    public interface IFlatBusiness
    {
        Guid AddFlatApplication(FullFlatApplicationSharedModel model);
        List<FlatSharedModel> GetAllSubmittedApllications();
        CreateUpdateFlatSharedModel GetFlatApplication(Guid FlatId);
        List<FlatSharedModel> GetAllApprovedApllications();     
        void ProcessApplication(CreateUpdateFlatSharedModel createUpdateFlatSharedModel, Guid[] Amenities, Guid[] RoomTypes);
        Guid GetApplicantUserId(Guid FlatId);
        void AddLandLord(AddLandLordSharedModel addLandLord);
        List<FlatSharedModel> GetFlatsToAddRooms();
        void SubmitApplicationForActivation(CreateUpdateFlatSharedModel createUpdateFlatSharedModel);
        List<FlatViewModel> GetLatestFlats();
        CreateUpdateFlatSharedModel GetFlatPopulatedWithRommtypesAndAmenities(Guid FlatId);
        List<FlatViewModel> GetPaginatedListFlats(int page, string keyword);
        Pagination PopulatePagination(string keyword, int page);
        int GetCountPaginatedListFlats(string keyword);
        List<FlatRoomTypesSharedModel> GetFlatRoomTypesByFlatId(Guid FlatId);
        List<CreateUpdateFlatSharedModel> GetAllUserFlats(Guid userId);
    }
}

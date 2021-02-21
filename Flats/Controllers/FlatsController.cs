using Flats.BusinessLogic.FlatBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flats.SharedModel.FlatSharedModels;
using Flats.BusinessLogic.AmenitiesBusiness;
using Flats.BusinessLogic.RoomtypeBusiness;
using Microsoft.AspNet.Identity;
using Flats.SharedModel.RoomTypeSharedModel;
using Flats.SharedModel.UserSharedModel;
using Flats.SharedModel.AmenitiesSharedModel;

namespace Flats.Controllers
{
    [Authorize]
    public class FlatsController : Controller
    {
        
        private readonly IFlatBusiness  _flatBusiness;
        private readonly IAmenitiesBusiness _amenitiesBusiness;
        private readonly IRoomTypeBusiness _roomTypeBusiness;
        // GET: Amenities
        public FlatsController()
        {
            _amenitiesBusiness = new AmenitiesBusiness();
            _roomTypeBusiness = new RoomTypeBusiness();
            _flatBusiness = new FlatBusiness();
        }
        // GET: Flats
        public ActionResult FlatApplication()
        {       
            return View();
        }

        [HttpPost]
    
        [ValidateAntiForgeryToken]
        public ActionResult FlatApplication(CreateUpdateFlatSharedModel createUpdateFlatSharedModel)
        {
            if (ModelState.IsValid)
            {
            createUpdateFlatSharedModel.UserId = new Guid(User.Identity.GetUserId());
                Session["FlatApplication"] = createUpdateFlatSharedModel;
                return RedirectToAction("Preview");
            }
            return View();
        }
        public ActionResult StartApplication()
        {
            var FlatViewModel = new CreateUpdateFlatSharedModel();
            FlatViewModel.ListAmenities = _amenitiesBusiness.GetAll();
            FlatViewModel.ListRoomTypes = GetAllRoomTypes();
            return View(FlatViewModel);
        }
        public ActionResult Preview()
        {
            return View((CreateUpdateFlatSharedModel)Session["FlatApplication"]);
        }
        [HttpPost]
        public ActionResult GetSelectedRoomTypes(Guid[] roomtypeId)
        {
            return View(new SelectedRoomTypes{ _roomtypeIds= PopulateRoomtypes(roomtypeId) });
        }
        public List<RoomTypeSharedModel> PopulateRoomtypes(Guid[] roomtypes)
        {
            var list = new List<RoomTypeSharedModel>();
            foreach(var  item in roomtypes)
            {
                list.Add(GetAllRoomTypes().Where(x => x.Id == item).FirstOrDefault());
            }
            return list;
        }
        public List<AmenitiesSharedModel> PopulaAmenities(Guid[] amenities)
        {
            var list = new List<AmenitiesSharedModel>();
            foreach (var item in amenities)
            {
                list.Add(GetAllAmenities().Where(x => x.Id == item).FirstOrDefault());
            }
            return list;
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult ReviewApplication(FullFlatApplicationSharedModel fullFlatApplicationSharedModel)
        {
            fullFlatApplicationSharedModel._listamenities = PopulaAmenities(fullFlatApplicationSharedModel.Amenities);
            fullFlatApplicationSharedModel._listflatroomtypes = PopulateFlatRoomType(fullFlatApplicationSharedModel.DepositWithIds,fullFlatApplicationSharedModel.RentWithIds, fullFlatApplicationSharedModel.RoomTypes);
            return View(fullFlatApplicationSharedModel);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SubmitApplication(FullFlatApplicationSharedModel fullFlatApplicationSharedModel)
        {
            fullFlatApplicationSharedModel._listamenities = PopulaAmenities(fullFlatApplicationSharedModel.Amenities);
            fullFlatApplicationSharedModel._listflatroomtypes = PopulateFlatRoomType(fullFlatApplicationSharedModel.DepositWithIds, fullFlatApplicationSharedModel.RentWithIds, fullFlatApplicationSharedModel.RoomTypes);
            fullFlatApplicationSharedModel.UserId = new Guid(User.Identity.GetUserId());
            Guid flatId= _flatBusiness.AddFlatApplication(fullFlatApplicationSharedModel);
            return Json(flatId, JsonRequestBehavior.AllowGet);
        }

        public List<FlatRoomTypesSharedModel> PopulateFlatRoomType( string[] deposit, string[] rent,Guid[] Id)
        {
            var list = new  List<FlatRoomTypesSharedModel>();
            foreach (var  item in Id)
            {
                list.Add(new FlatRoomTypesSharedModel
                {
                    RoomTypeId = item,
                   Name = GetAllRoomTypes().Where(x => x.Id == item).FirstOrDefault().Name,
                    Deposit = ProccessDepositList(deposit).Where(x => x.Id == item).FirstOrDefault().Amount,
                    Rent = ProccessRentList(rent).Where(x => x.Id == item).FirstOrDefault().Amount
                }); 
            }
            return list;
        }

        public List<IdAndAmount> ProccessRentList(string[] rentlist)
        {
            var list = new List<IdAndAmount>();
            foreach (var item in rentlist)
            {
                string[] arr = item.Split('|');
                list.Add(new IdAndAmount { Id=new Guid(arr[0]), Amount=decimal.Parse(arr[1]) } );
            }
            return list;
        }
        public List<IdAndAmount> ProccessDepositList(string[] depositlist)
        {
            var list = new List<IdAndAmount>();
            foreach (var item in depositlist)
            {
                string[] arr = item.Split('|');
                list.Add(new IdAndAmount { Id = new Guid(arr[0]), Amount = decimal.Parse(arr[1]) });
            }
            return list;
        }

        [OutputCache(Duration = 3600)]
        public List<RoomTypeSharedModel> GetAllRoomTypes()
        {
            return _roomTypeBusiness.GetAllRoomTypes();
        }
        [OutputCache(Duration = 3600)]
        public List<AmenitiesSharedModel> GetAllAmenities()
        {
            return _amenitiesBusiness.GetAll();
        }
    }
    
}
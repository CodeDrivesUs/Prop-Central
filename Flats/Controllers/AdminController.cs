using Flats.BusinessLogic.AmenitiesBusiness;
using Flats.BusinessLogic.FlatBusiness;
using Flats.BusinessLogic.RoomBusiness;
using Flats.BusinessLogic.RoomtypeBusiness;
using Flats.SharedModel.FlatSharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Flats.BusinessLogic.UsereBusiness;
using Flats.SharedModel.AdminSharedModel;
using Flats.SharedModel.RoomSharedModel;

namespace Flats.Controllers
{
    public class AdminController : Controller
    {
        private IFlatBusiness _flatBusiness;
        private IAmenitiesBusiness _amenitiesBusiness;
        private IRoomTypeBusiness _roomTypeBusiness;
        private IUsereBusiness  _usereBusiness;
        private IRoomBusiness _roomBusiness;
        public AdminController()
        {
            _flatBusiness = new FlatBusiness();
            _amenitiesBusiness = new AmenitiesBusiness();
            _roomTypeBusiness = new RoomTypeBusiness();
            _usereBusiness = new UsereBusiness();
            _roomBusiness = new RoomBusiness();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FlatApplications()
        {
            return View(_flatBusiness.GetAllSubmittedApllications());
        }
        public ActionResult ProcessApplication(Guid? FlatId)
        {
            if (FlatId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var flatapplication = _flatBusiness.GetFlatApplication((Guid)FlatId);
            if (flatapplication == null)
            {
                return HttpNotFound();
            }
            flatapplication.ListAmenities = _amenitiesBusiness.GetAll();
            flatapplication.ListRoomTypes = _roomTypeBusiness.GetAllRoomTypes();
            return View(flatapplication);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessApplication(CreateUpdateFlatSharedModel createUpdateFlatSharedModel, Guid[] Amenities, Guid[] RoomTypes)
        {
            createUpdateFlatSharedModel.UserId = new Guid(User.Identity.GetUserId());
            _flatBusiness.ProcessApplication(createUpdateFlatSharedModel,Amenities,RoomTypes);
            return RedirectToAction("AddLandLord", new { FlatId=createUpdateFlatSharedModel.Id });
        }
        public ActionResult AddRoomTypes(Guid FlatId)
        {
            return View();
        }
        public ActionResult AddLandLord(Guid FlatId)
        {
            Guid userid = _flatBusiness.GetApplicantUserId(FlatId);
            var User = _usereBusiness.GetUserById(userid);
            return View(new AddLandLordSharedModel { userSharedModel=User });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLandLord(AddLandLordSharedModel addLandLordSharedModel)
        {
            if (ModelState.IsValid)
            {
                 addLandLordSharedModel.AdminId = new Guid(User.Identity.GetUserId());
                _flatBusiness.AddLandLord(addLandLordSharedModel);
                return View("Sucess", new Success { Title="Success", Body="LandLord successfully added to the system" });
            }
            return View(addLandLordSharedModel);
        }
        public ActionResult FlatsToManageRooms()
        {
            return View(_flatBusiness.GetFlatsToAddRooms());
        }
        public ActionResult ManageRooms( Guid? FlatId)
        {
            if (FlatId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var flatapplication = _flatBusiness.GetFlatApplication((Guid)FlatId);
            if (flatapplication == null)
            {
                return HttpNotFound();
            }   
            
            return View(new CreateUpdateRoomSharedModel { listRoomTypes= _roomTypeBusiness.GetRoomTypeByFlatId((Guid)FlatId), FlatId= (Guid)FlatId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageRooms(CreateUpdateRoomSharedModel createUpdateRoomSharedModel)
        {
            if (ModelState.IsValid)
            {
                _roomBusiness.AddRoom(createUpdateRoomSharedModel);
                return View("Sucess", new Success { Title = "Success", Body = "Room successfully added to the system" });
            }
            return View(createUpdateRoomSharedModel);
        }
    }
}
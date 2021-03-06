using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Flats.BusinessLogic.FlatBusiness;
using Flats.BusinessLogic.FlatImageBusiness;
using Flats.BusinessLogic.RoomBookingBusiness;
using Flats.SharedModel.LandLordSharedModels;
using Flats.SharedModel.RoomOccupantSharedModels;
using Flats.BusinessLogic.RoomOccupantBusiness;
using Microsoft.AspNet.Identity;
using Flats.SharedModel.CamaraSharedModels;
using Flats.SharedModel.AdminSharedModel;
using Flats.SharedModel.FlatSharedModels;
using Flats.SharedModel.FlatImageSharedModel;

namespace Flats.Controllers
{
    [Authorize]
    public class LandLordController : Controller
    {
        private IFlatBusiness _flatBusiness;
        private IFlatImageBusiness _flatImageBusiness;
        private IRoomBookingBusiness _roomBookingBusiness;
        private IRoomOccupantBusiness  _roomOccupantBusiness;
        public LandLordController()
        {
            _roomOccupantBusiness = new RoomOccupantBusiness();
            _roomBookingBusiness = new RoomBookingBusiness();
            _flatBusiness = new FlatBusiness();
            _flatImageBusiness = new FlatImageBusiness();
        }
        public ActionResult MyFlats()
        {        
            return View(new MyFlatsIndex { _ListFlats=_flatBusiness.GetAllUserFlats(new Guid(User.Identity.GetUserId())) });
        }
        public ActionResult FlatDashBord(Guid? FlatId)
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
            return View(new FlatDashboard { flat = flatapplication, ProfilePicture = _flatImageBusiness.GetProfilePicture((Guid)FlatId), roomtypes = _flatBusiness.GetFlatRoomTypesByFlatId((Guid)FlatId) });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddProfilePicture(FlatImageSharedModel flatImage)
        {
            _flatImageBusiness.AddProfilePicture(flatImage);
            return RedirectToAction("FlatDashBord", new { FlatId = flatImage.FlatId });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public JsonResult AddRoomImage(FlatImageSharedModel flatImage, string[] ImageUrl)
        {
            _flatImageBusiness.AddRoomImage(flatImage, ImageUrl);
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SubmitFlatForActivation(Guid FlatId)
        {
            _flatBusiness.SubmitApplicationForActivation(new CreateUpdateFlatSharedModel { Id = FlatId, UserId = new Guid(User.Identity.GetUserId()) });
            return View("Success", new Success { Title = "Flat Submitted For Activation", Body = "You have  succesfully Submitted the flat  for activation pending  an Adminstration approval" });
        }
        // GET: LandLord
        public ActionResult Index(Guid? FlatId)
        {
            if (FlatId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var flat = _flatBusiness.GetFlatPopulatedWithRommtypesAndAmenities((Guid)FlatId);
            if (flat == null)
            {
                return HttpNotFound();
            }

            return View(new LandLordIndex { _flat = flat, ProfilePicture = _flatImageBusiness.GetProfilePicture((Guid)FlatId).ImageUrl,  _flatBookings = _roomBookingBusiness.GetRoomBookingsForAFlat((Guid)FlatId) });
        }
        [HttpGet]
        public ActionResult Proccess(Guid bookingId)
        {
            var booking = _roomBookingBusiness.PopulateRoomOccupantByBookingId(bookingId);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }
        public ActionResult AddApplicatntToARoom(Guid?  bookingId)
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Proccess(RoomOccupantSharedModel roomOccupantSharedModel)
        {
            return View();
        }
    }
}
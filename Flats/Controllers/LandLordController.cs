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


namespace Flats.Controllers
{
    public class LandLordController : Controller
    {
        private IFlatBusiness _flatBusiness;
        private IFlatImageBusiness _flatImageBusiness;
        private IRoomBookingBusiness _roomBookingBusiness;

        public LandLordController()
        {
            _roomBookingBusiness = new RoomBookingBusiness();
            _flatBusiness = new FlatBusiness();
            _flatImageBusiness = new FlatImageBusiness();
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
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Proccess(Guid bookingId)
        {
            return View(_roomBookingBusiness.GetRoomBookingById(bookingId));
        }
    }
}
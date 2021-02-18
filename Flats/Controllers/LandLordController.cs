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


namespace Flats.Controllers
{
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
        //[HttpPost, ValidateAntiForgeryToken]
        //public ActionResult Proccess(RoomOccupantSharedModel roomOccupantSharedModel)
        //{
        //    return View();
        //}
    }
}
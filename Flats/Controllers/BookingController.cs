using Flats.SharedModel.RoomBookingSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Flats.BusinessLogic.RoomBookingBusiness;

namespace Flats.Controllers
{
    public class BookingController : Controller
    {
        private readonly IRoomBookingBusiness _roomBookingBusiness;
        public BookingController()
        {
            _roomBookingBusiness = new RoomBookingBusiness();
        }
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken,Authorize]
        public ActionResult Book(RoomBookingSharedModel roomBookingSharedModel)
        {
            string userId = User.Identity.GetUserId();
            roomBookingSharedModel.UseriId = new Guid(userId);
            _roomBookingBusiness.AddRoomBooking(roomBookingSharedModel);
            return View("Sucess");
        }
      
    }
}
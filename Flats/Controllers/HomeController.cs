using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flats.SharedModel.HomeSharedModel;
using Flats.BusinessLogic.RoomtypeBusiness;
using Flats.BusinessLogic.FlatBusiness;

namespace Flats.Controllers
{
    public class HomeController : Controller
    {
        private IRoomTypeBusiness _roomTypeBusiness;
        private IFlatBusiness  _flatBusiness;
        public HomeController()
        {
            _flatBusiness = new FlatBusiness();
            _roomTypeBusiness = new RoomTypeBusiness();
        }
        public ActionResult Index()
        {
            return View( new HomeSharedmodel {RoomTypes= _roomTypeBusiness.GetAllRoomTypes() , LatestFlats=_flatBusiness.GetLatestFlats()});
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flats.SharedModel.HomeSharedModel;
using Flats.SharedModel.FlatSharedModels;
using Flats.BusinessLogic.RoomtypeBusiness;
using Flats.BusinessLogic.FlatBusiness;
using System.Net;
using Flats.BusinessLogic.FlatImageBusiness;

namespace Flats.Controllers
{
    public class HomeController : Controller
    {
        private IRoomTypeBusiness _roomTypeBusiness;
        private IFlatBusiness  _flatBusiness;
        private IFlatImageBusiness _flatImageBusiness;

        public HomeController()
        {
            _flatBusiness = new FlatBusiness();
            _roomTypeBusiness = new RoomTypeBusiness();
            _flatImageBusiness = new FlatImageBusiness();
        }
        public ActionResult Index()
        {
          
            return View( new HomeSharedmodel {RoomTypes= _roomTypeBusiness.GetAllRoomTypes() , LatestFlats=_flatBusiness.GetLatestFlats()});
        }
        public ActionResult ViewFlat(Guid? FlatId)
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

            return View( new FlatSharedModel { _flat=flat, ProfilePicture=_flatImageBusiness.GetProfilePicture((Guid)FlatId).ImageUrl, AllPictures=_flatImageBusiness.GetGalleryImagesForAFlat((Guid)FlatId) });
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
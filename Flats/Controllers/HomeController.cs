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
using System.IO;

namespace Flats.Controllers
{
    public class HomeController : Controller
    {
        private IRoomTypeBusiness _roomTypeBusiness;
        private IFlatBusiness _flatBusiness;
        private IFlatImageBusiness _flatImageBusiness;

        public HomeController()
        {
            _flatBusiness = new FlatBusiness();
            _roomTypeBusiness = new RoomTypeBusiness();
            _flatImageBusiness = new FlatImageBusiness();
        }
        public ActionResult Index()
        {

            return View(new HomeSharedmodel { RoomTypes = _roomTypeBusiness.GetAllRoomTypes(), LatestFlats = _flatBusiness.GetLatestFlats() });
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

            return View(new FlatSharedModel { _flat = flat, ProfilePicture = _flatImageBusiness.GetProfilePicture((Guid)FlatId).ImageUrl, AllPictures = _flatImageBusiness.GetGalleryImagesForAFlat((Guid)FlatId) });
        }
        public ActionResult FindFlat()
        {

            return View(new FindFlatSharedModel { RoomTypes = _roomTypeBusiness.GetAllRoomTypes() });
        }
        [HttpPost]
        public ActionResult FindFlat(string Search)
        {
            return View(new  FindFlatSharedModel { RoomTypes = _roomTypeBusiness.GetAllRoomTypes(), Keyword=Search });
        }
      
      
        [HttpGet]
        public JsonResult Pagination(int page, string keyword)
        {
            keyword = EscApostrophe(keyword);
            return Json(new { PaginationList = ConvertPartialViewToString(PartialView("_flats", _flatBusiness.GetPaginatedListFlats(page, keyword))), navigation = ConvertPartialViewToString(PartialView("_Pagination", _flatBusiness.PopulatePagination(keyword, page))) }, JsonRequestBehavior.AllowGet);
        }
  
        protected string ConvertPartialViewToString(PartialViewResult partialView)
        {
            using (var sw = new StringWriter())
            {
                partialView.View = ViewEngines.Engines
                  .FindPartialView(ControllerContext, partialView.ViewName).View;

                var vc = new ViewContext(
                  ControllerContext, partialView.View, partialView.ViewData, partialView.TempData, sw);
                partialView.View.Render(vc, sw);

                var partialViewString = sw.GetStringBuilder().ToString();

                return partialViewString;
            }
        }
        public  string EscApostrophe(string str)
        {
            return str != null ? str.Replace("'", "''") : "''";
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Flats.BusinessLogic.FlatBusiness;
using Flats.BusinessLogic.FlatImageBusiness;
using Flats.SharedModel.CamaraSharedModels;
using Flats.SharedModel.FlatImageSharedModel;
using Flats.BusinessLogic.RoomtypeBusiness;
using Flats.SharedModel.FlatSharedModels;
using Microsoft.AspNet.Identity;
using Flats.SharedModel.AdminSharedModel;

namespace Flats.Controllers
{
    public class CamaraController : Controller
    {
        private IFlatBusiness _flatBusiness;
        private IFlatImageBusiness _flatImageBusiness;
        private IRoomTypeBusiness _roomTypeBusiness;
        public CamaraController()
        {
            _flatImageBusiness = new FlatImageBusiness();
            _flatBusiness = new FlatBusiness();
            _roomTypeBusiness = new RoomTypeBusiness();
        }
        // GET: Camara
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetApprovedApplications()
        {
            return View(_flatBusiness.GetAllApprovedApllications());
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
            return View(new FlatDashboard { flat =flatapplication, ProfilePicture = _flatImageBusiness.GetProfilePicture((Guid)FlatId), roomtypes= _roomTypeBusiness.GetRoomTypeByFlatId((Guid)FlatId) });
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult AddProfilePicture(FlatImageSharedModel flatImage)
        {
            _flatImageBusiness.AddProfilePicture(flatImage);
            return RedirectToAction("FlatDashBord", new { FlatId=flatImage.FlatId });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public JsonResult AddRoomImage(FlatImageSharedModel flatImage, string[] ImageUrl)
        {         
            _flatImageBusiness.AddRoomImage(flatImage ,ImageUrl );
            return Json("",JsonRequestBehavior.AllowGet);          
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SubmitFlatForActivation(Guid FlatId)
        {
            _flatBusiness.SubmitApplicationForActivation(new CreateUpdateFlatSharedModel { Id=FlatId, UserId= new Guid(User.Identity.GetUserId())});
            return View("Success", new Success { Title="Flat Submitted For Activation", Body="You have  succesfully Submitted the flat  for activation pending  an Adminstration approval" });
        }
    }
}
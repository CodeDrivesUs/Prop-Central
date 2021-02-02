using Flats.BusinessLogic.FlatBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flats.SharedModel.FlatSharedModels;
using Microsoft.AspNet.Identity;
namespace Flats.Controllers
{
    [Authorize]
    public class FlatsController : Controller
    {
        
        private  IFlatBusiness  _flatBusiness;
        // GET: Amenities
        public FlatsController()
        {
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

        public ActionResult Preview()
        {
            return View((CreateUpdateFlatSharedModel)Session["FlatApplication"]);
        }
        public ActionResult SubmitApplication()
        {
            _flatBusiness.Add((CreateUpdateFlatSharedModel)Session["FlatApplication"]);
            return View("Sucess");
        }


    }
}
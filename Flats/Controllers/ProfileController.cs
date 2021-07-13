using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flats.BusinessLogic.ProfileBusiness;
using Flats.SharedModel.Profile;
using Microsoft.AspNet.Identity;

namespace Flats.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileBusiness _profileBusiness;
        public ProfileController()
        {
            _profileBusiness = new ProfileBusiness();
        }
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult MyProfile()
        {
            return View(_profileBusiness.GetFullProfileByUserId(new Guid( User.Identity.GetUserId())));
        }
        [HttpPost]
        public ActionResult MyProfile(ProfileSharedModel model )
        {
            _profileBusiness.UpdateProFile(model);
            return RedirectToAction("MyProfile");
        }

        }
}
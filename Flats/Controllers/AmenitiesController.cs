using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Flats.BusinessLogic.AmenitiesBusiness;
using Flats.SharedModel.AmenitiesSharedModel;

namespace Flats.Controllers
{
    public class AmenitiesController : Controller
    {
        private IAmenitiesBusiness _amenitiesBusiness;
        // GET: Amenities
        public AmenitiesController()
        {
            _amenitiesBusiness = new AmenitiesBusiness();
        }
        public ActionResult Index()
        {
            return View(_amenitiesBusiness.GetAll());
        }

        // GET: Amenities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AmenitiesSharedModel amenities =  _amenitiesBusiness.Get((int)id);
            if (amenities == null)
            {
                return HttpNotFound();
            }
            return View(amenities);
        }

        // GET: Amenities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AmenitiesSharedModel amenitiesSharedModel)
        {
            if (ModelState.IsValid)
            {
                _amenitiesBusiness.Add(amenitiesSharedModel);
                return RedirectToAction("Index");
            
            }

            return View(amenitiesSharedModel);
        }

        // GET: Amenities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AmenitiesSharedModel amenities =  _amenitiesBusiness.Get((int)id);
            if (amenities == null)
            {
                return HttpNotFound();
            }
            return View(amenities);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AmenitiesSharedModel amenitiesSharedModel)
        {
            if (ModelState.IsValid)
            {
                _amenitiesBusiness.Update(amenitiesSharedModel);
                return RedirectToAction("Index");
            }
            return View(amenitiesSharedModel);
        }

        // GET: Amenities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AmenitiesSharedModel amenities =  _amenitiesBusiness.Get((int)id);

            if (amenities == null)
            {
                return HttpNotFound();
            }
            return View(amenities);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _amenitiesBusiness.Delete(id);
            return RedirectToAction("Index");
        }
      
    }
}
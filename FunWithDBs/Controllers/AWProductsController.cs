using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FunWithDBs.Models;

namespace FunWithDBs.Controllers
{ 
    public class AWProductsController : Controller
    {
        private AdventureWorksDWEntities1 db = new AdventureWorksDWEntities1();

        //
        // GET: /AWProducts/

        public ViewResult Index()
        {
            return View(db.DimProduct.ToList());
        }

        //
        // GET: /AWProducts/Details/5

        public ViewResult Details(int id)
        {
            DimProduct dimproduct = db.DimProduct.Find(id);
            return View(dimproduct);
        }

        //
        // GET: /AWProducts/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AWProducts/Create

        [HttpPost]
        public ActionResult Create(DimProduct dimproduct)
        {
            if (ModelState.IsValid)
            {
                db.DimProduct.Add(dimproduct);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(dimproduct);
        }
        
        //
        // GET: /AWProducts/Edit/5
 
        public ActionResult Edit(int id)
        {
            DimProduct dimproduct = db.DimProduct.Find(id);
            return View(dimproduct);
        }

        //
        // POST: /AWProducts/Edit/5

        [HttpPost]
        public ActionResult Edit(DimProduct dimproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dimproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dimproduct);
        }

        //
        // GET: /AWProducts/Delete/5
 
        public ActionResult Delete(int id)
        {
            DimProduct dimproduct = db.DimProduct.Find(id);
            return View(dimproduct);
        }

        //
        // POST: /AWProducts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            DimProduct dimproduct = db.DimProduct.Find(id);
            db.DimProduct.Remove(dimproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
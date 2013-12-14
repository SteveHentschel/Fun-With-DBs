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
    public class AWEmployeesController : Controller
    {
        private AdventureWorksDWEntities db = new AdventureWorksDWEntities();

        //
        // GET: /AWEmployees/

        public ViewResult Index()
        {
            var dimemployees = db.DimEmployees.Include(d => d.DimEmployee2);
            return View(dimemployees.ToList());
        }

        //
        // GET: /AWEmployees/Details/5

        public ViewResult Details(int id)
        {
            DimEmployee dimemployee = db.DimEmployees.Find(id);
            return View(dimemployee);
        }

        //
        // GET: /AWEmployees/Create

        public ActionResult Create()
        {
            ViewBag.ParentEmployeeKey = new SelectList(db.DimEmployees, "EmployeeKey", "EmployeeNationalIDAlternateKey");
            return View();
        } 

        //
        // POST: /AWEmployees/Create

        [HttpPost]
        public ActionResult Create(DimEmployee dimemployee)
        {
            if (ModelState.IsValid)
            {
                db.DimEmployees.Add(dimemployee);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ParentEmployeeKey = new SelectList(db.DimEmployees, "EmployeeKey", "EmployeeNationalIDAlternateKey", dimemployee.ParentEmployeeKey);
            return View(dimemployee);
        }
        
        //
        // GET: /AWEmployees/Edit/5
 
        public ActionResult Edit(int id)
        {
            DimEmployee dimemployee = db.DimEmployees.Find(id);
            ViewBag.ParentEmployeeKey = new SelectList(db.DimEmployees, "EmployeeKey", "EmployeeNationalIDAlternateKey", dimemployee.ParentEmployeeKey);
            return View(dimemployee);
        }

        //
        // POST: /AWEmployees/Edit/5

        [HttpPost]
        public ActionResult Edit(DimEmployee dimemployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dimemployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentEmployeeKey = new SelectList(db.DimEmployees, "EmployeeKey", "EmployeeNationalIDAlternateKey", dimemployee.ParentEmployeeKey);
            return View(dimemployee);
        }

        //
        // GET: /AWEmployees/Delete/5
 
        public ActionResult Delete(int id)
        {
            DimEmployee dimemployee = db.DimEmployees.Find(id);
            return View(dimemployee);
        }

        //
        // POST: /AWEmployees/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            DimEmployee dimemployee = db.DimEmployees.Find(id);
            db.DimEmployees.Remove(dimemployee);
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
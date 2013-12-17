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
            ViewBag.DepartmentName = new SelectList(GenDeptList());

            return View(db.DimEmployees.ToList());
        }

        private List<string> GenDeptList()                      // Setup unique dropdown list for depts.
        {
            var deptList = new List<string>();                  // create string list to hold departments
            var deptQuery = from d in db.DimEmployees           // populate list with all departments
                            orderby d.DepartmentName
                            select d.DepartmentName;
            deptList.AddRange(deptQuery.Distinct());            // remove duplicate departments
            return deptList;
        }

        //
        // POST/GET: /AWEmployees/Filter
        public ActionResult Filter(DimEmployee dimemployee, bool salGreater, decimal? salary)
        {
            var model = from all in db.DimEmployees select all;         // grab all records to display
            ViewBag.DepartmentName = new SelectList(GenDeptList());     // set dept name dropdownlist
                         
            if (dimemployee.DepartmentName != null)                     //  filter by dept, if specified
            {
                model = model.Where(x => x.DepartmentName == dimemployee.DepartmentName); 
            }

            if (salary <= 0 || salary == null)                                          // No salary filter
                return View("Index", model);
            else
            {
                if (salGreater == true) model = model.Where(s => s.BaseRate >= salary); // Salary filters
                else model = model.Where(s => s.BaseRate <= salary);
                    return View("Index", model);     
            }
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
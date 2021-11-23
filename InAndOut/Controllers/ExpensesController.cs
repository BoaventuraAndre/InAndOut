using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _db;


        public ExpensesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expenses> objList = _db.MyExpenses;
            return View(objList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Expenses obj)
        {
            if (ModelState.IsValid)
            {
                _db.MyExpenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        //get delete
        public IActionResult Delete(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.MyExpenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            
            return View(obj);


        }
        //postdelete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost (int? id)
        {
            var obj = _db.MyExpenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
           
                _db.MyExpenses.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
                    
        }
        // getupdate
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.MyExpenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
            return View(obj);


        }
        //postupdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expenses obj)
        {
            if (ModelState.IsValid)
            {
                _db.MyExpenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }



    }
}

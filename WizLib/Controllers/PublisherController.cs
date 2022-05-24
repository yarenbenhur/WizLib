using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizLib_DataAccess.Data;
using WizLib_Model.Models;

namespace WizLib.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Publisher> objList = _db.Publishers.ToList();
            return View(objList);

        }
        public IActionResult Upsert(int? id)
        {
            Publisher obj = new Publisher();
            if (id == null)
            {
                return View(obj);
            }
            else
            {
                obj = _db.Publishers.First(u => u.Publisher_Id == id);
                return (obj == null) ? NotFound() : View(obj);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Publisher obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Publisher_Id == 0)
                {
                    _db.Publishers.Add(obj);
                }
                else
                {
                    _db.Publishers.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
           

        }
        public IActionResult Delete(int id)
        {
            var objFromDb = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            _db.Publishers.Remove(objFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
      
    }
}

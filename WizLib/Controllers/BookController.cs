using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizLib_DataAccess.Data;
using WizLib_Model.Models;
using WizLib_Model.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace WizLib.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Book> objList = _db.Books.ToList();
            foreach(var obj in objList)
            {
               /* obj.Publisher = _db.Publishers.FirstOrDefault(i => i.Publisher_Id == obj.Publisher_Id);*///loads number of books, least efficient
                _db.Entry(obj).Reference(i => i.Publisher).Load(); // loads number of publisher
            }
           
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM obj = new BookVM();
            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem { Text = i.Name, Value = i.Publisher_Id.ToString() });

            if (id == null)
            {
                return View(obj);
            }
            obj.Book = _db.Books.FirstOrDefault(U => U.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookVM obj)
        {

            if (obj.Book.Book_Id == 0)
            {
                _db.Books.Add(obj.Book);
            }
            else
            {
                _db.Books.Update(obj.Book);
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            BookVM obj = new BookVM();
           
            if (id == null)
            {
                return View(obj);
            }
            obj.Book = _db.Books.FirstOrDefault(U => U.Book_Id == id);
            obj.Book.Detail = _db.Details.FirstOrDefault(u => u.Detail_Id == obj.Book.Detail_Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(BookVM obj)
        {

            if (obj.Book.Detail.Detail_Id == 0)
            {
                _db.Books.Add(obj.Book);
                _db.SaveChanges();
                var BookFromDb = _db.Books.FirstOrDefault(u => u.Book_Id == obj.Book.Book_Id);
                BookFromDb.Detail_Id = obj.Book.Detail_Id;
                _db.SaveChanges();
            }
            else
            {
                _db.Details.Update(obj.Book.Detail);
                _db.SaveChanges();
            }
           
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var objFromDb = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            _db.Books.Remove(objFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}


using CookiesNSession.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiesNSession.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(BookModel book)
        {
            var listInSession=HttpContext.Session.Get<List<BookModel>>("Kitaplar");
            
            if (listInSession==default)
            {
                listInSession = new List<BookModel>();
                listInSession.Add(book);
                HttpContext.Session.Set<List<BookModel>>("Kitaplar", listInSession);
            }
            else
            {
                listInSession.Add(book);
                HttpContext.Session.Set<List<BookModel>>("Kitaplar", listInSession);
            }

            return View("BookList", listInSession);
        }


        [HttpPost]
        public IActionResult AddFavorite(/*BookModel book*/)
        {
            return View();
        }


    }
}

using CookiesNSession.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiesNSession.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]// Kitap ekleme sayfasına yönlendirir
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]//Eklenmek istenen kitabı Sessiona ekler, Kitap listesi sayfasına yönlendirir
        public IActionResult AddBook(BookModel book)
        {
            var listInSession=HttpContext.Session.Get<List<BookModel>>("Kitaplar");

            if (listInSession == default)
            { listInSession = new List<BookModel>(); }
            
            listInSession.Add(book);
            HttpContext.Session.Set<List<BookModel>>("Kitaplar", listInSession);

            return RedirectToAction("BookList","Book");
        }

        public IActionResult BookList()
        {
            var listInSession = HttpContext.Session.Get<List<BookModel>>("Kitaplar");

            if (listInSession == default)   // Kaydedilmiş kitap yok ise
                ViewBag.EmptyList = "Kaydedilmiş kitap yok";

            if (Request.Cookies.ContainsKey("favoriKitap"))// favori kitap varsa
                ViewBag.FavoriKitap = Request.Cookies["favoriKitap"];

            return View("BookList",listInSession);
        }

        [HttpPost]
        public IActionResult AddFavorite(BookModel book)
        {

            CookieOptions options = new CookieOptions();
            options.Path = "/";
            options.Expires = new DateTimeOffset(DateTime.Now.AddMinutes(10));

            
            Response.Cookies.Append("favoriKitap",book.Name , options);


            return RedirectToAction("BookList","Book");
        }


    }
}

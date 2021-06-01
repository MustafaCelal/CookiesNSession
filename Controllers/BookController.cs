using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiesNSession.Controllers
{
    public class BookController : Controller
    {
        public IActionResult AddBook()
        {
            return View();
        }

    }
}

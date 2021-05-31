using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookiesNSession.Models
{
    public class BookModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
    }
}

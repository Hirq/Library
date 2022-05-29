using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Web.Models
{
    public class RentalFormViewModel
    {
        public string Person { get; set; }
        public DateTime Date { get; set; }

        public int Book { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Rental> Rentals { get; set; } 
    }
}
using System;

namespace Library.Data.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public DateTime Date { get; set; }
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
    }
}

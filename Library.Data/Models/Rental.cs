using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public string Person { get; set; }
        public DateTime Date { get; set; }
    }
}

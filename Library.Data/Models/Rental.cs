using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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

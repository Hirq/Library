using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Autor  { get; set; }
        public BookType TypeBook { get; set; }
        public bool IsRental{ get; set; }
    }
}

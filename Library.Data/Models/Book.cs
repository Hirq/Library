using Library.Data.Models.Enum;

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

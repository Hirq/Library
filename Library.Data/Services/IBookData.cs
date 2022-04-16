using Library.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Services
{
    public interface IBookData
    {
        IEnumerable<Book> GetAll();
        Book Get(int id);   
        void Add(Book book);    
        void Update(Book book); 
        void Delete(int id);

    }
}

using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Services
{
    public interface IOpinionData
    {
        IEnumerable<Opinion> GetAll(int id);
        Opinion Get(int id);
        void Add(Opinion opinion);
        void Update(Opinion opinion);
        void Delete(int id);
        Restaurant GetRestaurant(int id);
    }
}

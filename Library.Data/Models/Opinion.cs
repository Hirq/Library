using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class Opinion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Who { get; set; }
        public double GradeFood { get; set; }
        public double GradeDrink { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}

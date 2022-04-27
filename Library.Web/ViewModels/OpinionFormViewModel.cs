using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Web.ViewModels
{
    public class OpinionFormViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Who { get; set; }
        public double GradeFood  { get; set; }
        public double GradeDrink  { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public IEnumerable<Opinion> Opinions { get; set; }
    }
}
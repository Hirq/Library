using Library.Data.Models;
using Library.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.Web.Api
{
    public class BooksController : ApiController
    {
        private readonly IBookData db;
        public BooksController(IBookData db )
        {
            this.db = db;
        }
        public IEnumerable<Book> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}

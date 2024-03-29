﻿using System.Linq;
using System.Web.Http;
using Breeze.ContextProvider;
using Breeze.WebApi2;
using Newtonsoft.Json.Linq;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    [BreezeController]
    public class BreezeController : ApiController, IRepository 
    {
        private readonly IRepository _repo;


        public BreezeController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public string MetaData()
        {
            return _repo.MetaData();
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _repo.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<Book> Books()
        {
            return _repo.Books();
        }

        [HttpGet]
        public IQueryable<Order> Orders()
        {
            return _repo.Orders();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using commerce.Core;
using commerce.Core.Models;
using commerce.Repositories;

namespace commerce.Controllers.API
{
    public class CustomerController : ApiController
    {
        private readonly IUnitOfWork _db;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult DeleteApplicationUser(string id)
        {
            ApplicationUser applicationUser = _db.ApplicationUsers.Get(id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            _db.ApplicationUsers.Remove(applicationUser);
            _db.Save();

            return Ok(applicationUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
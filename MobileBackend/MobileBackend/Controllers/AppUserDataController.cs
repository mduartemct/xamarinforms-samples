using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using MobileBackend.DataObjects;
using MobileBackend.Models;

namespace MobileBackend.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using MobileBackend.DataObjects;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<AppUser>("AppUserData");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class AppUserDataController : ODataController
    {
        private MobileServiceContext db = new MobileServiceContext();

        // GET: odata/AppUserData
        [EnableQuery]
        public IQueryable<AppUser> GetAppUserData()
        {
            return db.AppUsers;
        }

        // GET: odata/AppUserData(5)
        [EnableQuery]
        public SingleResult<AppUser> GetAppUser([FromODataUri] string key)
        {
            return SingleResult.Create(db.AppUsers.Where(appUser => appUser.Id == key));
        }

        // PUT: odata/AppUserData(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<AppUser> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AppUser appUser = db.AppUsers.Find(key);
            if (appUser == null)
            {
                return NotFound();
            }

            patch.Put(appUser);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(appUser);
        }

        // POST: odata/AppUserData
        public IHttpActionResult Post(AppUser appUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppUsers.Add(appUser);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AppUserExists(appUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(appUser);
        }

        // PATCH: odata/AppUserData(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<AppUser> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AppUser appUser = db.AppUsers.Find(key);
            if (appUser == null)
            {
                return NotFound();
            }

            patch.Patch(appUser);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(appUser);
        }

        // DELETE: odata/AppUserData(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            AppUser appUser = db.AppUsers.Find(key);
            if (appUser == null)
            {
                return NotFound();
            }

            db.AppUsers.Remove(appUser);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppUserExists(string key)
        {
            return db.AppUsers.Count(e => e.Id == key) > 0;
        }
    }
}

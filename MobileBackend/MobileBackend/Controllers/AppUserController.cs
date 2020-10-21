using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using MobileBackend.DataObjects;
using MobileBackend.Models;

namespace MobileBackend.Controllers
{
    public class AppUserController : TableController<AppUser>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<AppUser>(context, Request, enableSoftDelete: true);
        }

        // GET tables/AppUser
        public IQueryable<AppUser> GetAllAppUser()
        {
            return Query(); 
        }

        // GET tables/AppUser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<AppUser> GetAppUser(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/AppUser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<AppUser> PatchAppUser(string id, Delta<AppUser> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/AppUser
        public async Task<IHttpActionResult> PostAppUser(AppUser item)
        {
            AppUser current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/AppUser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAppUser(string id)
        {
             return DeleteAsync(id);
        }
    }
}

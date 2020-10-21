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
    public class CorpUserController : TableController<CorpUser>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<CorpUser>(context, Request);
        }

        // GET tables/CorpUser
        public IQueryable<CorpUser> GetAllCorpUser()
        {
            return Query(); 
        }

        // GET tables/CorpUser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CorpUser> GetCorpUser(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CorpUser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CorpUser> PatchCorpUser(string id, Delta<CorpUser> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/CorpUser
        public async Task<IHttpActionResult> PostCorpUser(CorpUser item)
        {
            CorpUser current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CorpUser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCorpUser(string id)
        {
             return DeleteAsync(id);
        }
    }
}

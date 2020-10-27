using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using MobileBackend.DataObjects;
using MobileBackend.Models;

namespace MobileBackend.Controllers
{
    [Authorize]
    public class TodoItemController : TableController<TodoItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<TodoItem>(context, Request);
        }

        /// <summary>
        /// Utilizado para pegar o Secure Identifier do Usuário logado acessando a API.
        /// </summary>
        public string UserSid
        {
            get
            {
                var principal = this.User as System.Security.Claims.ClaimsPrincipal;
                return principal.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            }
        }

        /// <summary>
        /// Utilizado para Validar um usuário autenticado nas operações de Insert, Update, Delete
        /// </summary>
        /// <param name="id"></param>
        public void ValidateOwner(string id)
        {
            var result = Lookup(id).Queryable.PerUserFilter(UserSid).FirstOrDefault<TodoItem>();
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        // GET tables/TodoItem
        public IQueryable<TodoItem> GetAllTodoItems()
        {
            return Query().PerUserFilter(UserSid);
            //return Query().Where(item => item.UserSId.Equals(UserSid));
            //return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TodoItem> GetTodoItem(string id)
        {
            return new SingleResult<TodoItem>(Lookup(id).Queryable.PerUserFilter(UserSid));
            //return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TodoItem> PatchTodoItem(string id, Delta<TodoItem> patch)
        {
            ValidateOwner(id);
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostTodoItem(TodoItem item)
        {
            item.UserSId = UserSid;
            TodoItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            ValidateOwner(id);
            return DeleteAsync(id);
        }
    }

    public static class TodoItemExtensions
    {
        public static IQueryable<TodoItem> PerUserFilter(this IQueryable<TodoItem> query, string userSid)
        {
            return query.Where(item => item.UserSId.Equals(userSid));
        }
    }
}
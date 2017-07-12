using BusinessLayer.InventarLogic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LittleHelperApi.Controllers
{
    /// <summary>
    /// Controller for Inventar Logics
    /// </summary>
    public class InventarController : ApiController
    {
        private readonly IInventarLogic _inventarLogic;

        /// <summary>
        /// Injection constructor
        /// </summary>
        /// <param name="inventarLogic"></param>
        public InventarController(IInventarLogic inventarLogic)
        {
            _inventarLogic = inventarLogic;
        }

        /// <summary>
        /// Collects the invenat of a user and returns it
        /// </summary>
        /// <param name="id">User id to identify the Inventar</param>
        /// <returns>A inventar of a single user</returns>
        public HttpResponseMessage GetUserInventar(int id)
        {
            var inventar = _inventarLogic.GetUsersInventar(id);

            if (inventar == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, inventar);
        }
    }
}

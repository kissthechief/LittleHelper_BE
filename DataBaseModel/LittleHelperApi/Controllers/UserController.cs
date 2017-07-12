using BusinessLayer.DTOs;
using BusinessLayer.UserLogic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LittleHelperApi.Controllers
{
    /// <summary>
    /// The Controller to handle all user actions
    /// </summary>
    public class UserController : ApiController
    {
        private readonly IUserLogic _userLogic;
        /// <summary>
        /// Injection Constructor
        /// </summary>
        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        /// <summary>
        /// Get the profile for a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/User/{id}")]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(HttpStatusCode.OK, Type = typeof(UserDto))]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(HttpStatusCode.NotFound)]
        public HttpResponseMessage Get (int id)
        {
            var user = _userLogic.Get(id);

            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        /// <summary>
        /// Update of a user profile if the user has the rights to do it
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/v1/User/UpdateProfile")]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(HttpStatusCode.OK, Type = typeof(UserDto))]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(HttpStatusCode.NotFound)]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(HttpStatusCode.BadRequest)]
        public HttpResponseMessage UpdateProfile (UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var updatedUser = _userLogic.Update(user);

            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, updatedUser);
        }
    }
}
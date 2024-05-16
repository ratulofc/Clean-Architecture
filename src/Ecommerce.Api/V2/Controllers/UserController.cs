//using Asp.Versioning;
using Ecommerce.Core.Exception;
using Ecommerce.Core.Interfaces.Services;
using Ecommerce.Core.Models;
using Ecommerce.Core.Request;
using Ecommerce.Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.V2.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/" + ApiConstants.ServiceName + "/v{api-version:apiVersion}/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.userService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Get the User by ID
        /// </summary>
        /// <returns>Return User</returns>
        /// <response code="200">200 ERROR Comeing</response>
        /// <response code="400">400 ERROR Comeing</response>
        /// <response code="404">404 ERROR Comeing</response>
        /// <response code="500">500 ERROR Comeing</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest();
            var result = await this.userService.GetById(id);
            if (result is not null) return Ok(result);
            return NotFound(new { message = $"Entity with ID => {id} Not Found" });
            //throw new UpdateNotFoundException("NEW ERROR");
        }

        /// <summary>
        /// Create an User
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     Post api/User
        ///     {
        ///         "Name" : "Ratul"
        ///         "Email" : "ratul@email.com"
        ///         "Age" : "24"
        ///     }
        /// </remarks>
        /// <param name="userRequest"></param>
        /// <returns>Added value</returns>
        [HttpPost]
        public async Task<IActionResult> Post(UserRequest userRequest)
        {
            var result = await this.userService.Add(userRequest);
            if (result is null) return BadRequest(new { message = "User already exiest in database" });
            return Ok(result);
        }
    }
}

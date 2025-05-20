using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBooking.Application.UseCases.User.GetUser;
using ServiceBooking.Application.UseCases.User.Register;
using ServiceBooking.Communication.Request.User;
using ServiceBooking.Communication.Response.User;
using ServiceBooking.Domain.Entities;
using ServiceBooking.Domain.Repositories;


namespace ServiceBooking.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

    
        [HttpGet]
        public async Task<IActionResult> RegisterUser([FromServices] IGetUsersUseCase useCase)
        {
            try
            {
                var result = await useCase.GetAllUsers();

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterUser([FromServices] IRegisterUserUseCase useCase, [FromBody] RequestRegisterUserJson request)
        {
            try
            {
                var result = await useCase.RegistrarUsuario(request);

                return Created(string.Empty, result);
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}

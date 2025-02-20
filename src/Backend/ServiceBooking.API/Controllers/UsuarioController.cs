using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBooking.Application.UseCases.User.Register;
using ServiceBooking.Communication.Request;
using ServiceBooking.Communication.Response;

namespace ServiceBooking.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterUser([FromServices] IRegisterUseCase useCase, [FromBody] RequestRegisterUserJson request)
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

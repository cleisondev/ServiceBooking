using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBooking.Application.UseCases.User.Register;
using ServiceBooking.Communication.Request.User;
using ServiceBooking.Communication.Response.User;

namespace ServiceBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
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

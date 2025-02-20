using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBooking.Application.UseCases.PrestadorServicos.Register;
using ServiceBooking.Application.UseCases.User.Register;
using ServiceBooking.Communication.Request.PrestadorServico;
using ServiceBooking.Communication.Request.User;
using ServiceBooking.Communication.Response.User;

namespace ServiceBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorServicoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterUser([FromServices] IRegisterPrestadorServicoUseCase useCase, [FromBody] RequestPrestadorServicoJson request)
        {
            try
            {
                var result = await useCase.RegistrarPrestadorServico(request);

                return Created(string.Empty, result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBooking.Application.UseCases.Servicos.Register;
using ServiceBooking.Application.UseCases.User.Register;
using ServiceBooking.Communication.Request.Servico;
using ServiceBooking.Communication.Request.User;
using ServiceBooking.Communication.Response;
using ServiceBooking.Communication.Response.User;
using ServiceBooking.Exceptions.ExceptionsBase;

namespace ServiceBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterUser([FromServices] IRegisterServicosUseCase useCase, [FromBody] RequestRegisterServiceJson request)
        {
            try
            {
                var result = await useCase.RegistrarServico(request);

                return Created(string.Empty, result);
            }
            catch (ErrorOnValidationException ex)
            {
                // A exceção será capturada pelo ExceptionFilter
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseErrorJson("Ocorreu um erro interno."));
            }
        }
    }
}

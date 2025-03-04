using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBooking.Application.UseCases.Servicos.Register;
using ServiceBooking.Communication.Request.Servico;
using ServiceBooking.Communication.Response.User;
using ServiceBooking.Communication.Response;
using ServiceBooking.Exceptions.ExceptionsBase;
using ServiceBooking.Communication.Request.Login;
using ServiceBooking.Application.UseCases.Login.DoLogin;

namespace ServiceBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterUser([FromServices] DoLoginUseCase useCase, [FromBody] RequestLoginJson request)
        {
            try
            {
                var result = await useCase.Login(request);

                return Ok("Login efetuado com sucesso");
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

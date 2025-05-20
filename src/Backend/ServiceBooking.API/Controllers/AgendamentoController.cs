using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBooking.Application.UseCases.PrestadorServicos.Register;
using ServiceBooking.Communication.Request.Agendamento;
using ServiceBooking.Communication.Request.PrestadorServico;
using ServiceBooking.Communication.Response.User;

namespace ServiceBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterUser([FromServices] IRegisterPrestadorServicoUseCase useCase, [FromBody] RequestAgendamentoServicoJson request)
        {
            try
            {
                var result = await useCase.(request);

                return Created(string.Empty, result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

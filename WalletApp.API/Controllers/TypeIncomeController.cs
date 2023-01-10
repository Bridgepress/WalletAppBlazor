using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Client.DTO.TypeIncome;
using WalletApp.CommandAndQuery.TypeIncome.CreateTypeIncome;
using WalletApp.CommandAndQuery.TypeIncome.DeleteTypeIncome;
using WalletApp.CommandAndQuery.TypeIncome.GetAllTypeIncome;

namespace WalletApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeIncomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TypeIncomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateTypeIncome")]
        public async Task<IActionResult> CreateTypeIncome(TypeIncomeDTO typeIncomeDTO)
        {
            var typeIncome = await _mediator.Send(new CreateTypeIncomeCommand(typeIncomeDTO.Name));
            if (typeIncome == null)
            {
                return BadRequest();
            }
            return Ok(typeIncome);
        }

        [HttpDelete("DeleteTypeIncome/{id}")]
        public async Task<IActionResult> DeleteTypeIncome(Guid id)
        {
            var typeIncomeDTO = await _mediator.Send(new DeleteTypeIncomeCommand(id));
            if (typeIncomeDTO == null)
            {
                return NotFound();
            }
            return Ok(typeIncomeDTO);
        }

        [HttpGet("GetAllTypeIncome")]
        public async Task<IEnumerable<TypeIncomeDetailsDTO>> GetAllTypeIncome()
        {
            var typeIncomeDTO = await _mediator.Send(new GetAllTypeIncomeQuery());
            return typeIncomeDTO;
        }
    }
}

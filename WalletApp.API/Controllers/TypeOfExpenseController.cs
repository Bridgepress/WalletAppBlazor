using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Client.DTO.TypeOfExpense;
using WalletApp.CommandAndQuery.TypeOfExpense.CreateTypeOfExpense;
using WalletApp.CommandAndQuery.TypeOfExpense.DeleteTypeOfExpense;
using WalletApp.CommandAndQuery.TypeOfExpense.GetAllTypeOfExpense;
using WalletApp.Domain.DTO.TypeOfExpense;

namespace WalletApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfExpenseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TypeOfExpenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateTypeOfExpense")]
        public async Task<IActionResult> CreateTypeOfExpense(TypeOfExpenseDTO typeOfExpenseDTO)
        {
            var typeOfExpense = await _mediator.Send(new CreateTypeOfExpenseCommand(typeOfExpenseDTO.Name));
            if (typeOfExpense == null)
            {
                return BadRequest();
            }
            return Ok(typeOfExpense);
        }

        [HttpDelete("DeleteTypeOfExpense/{id}")]
        public async Task<IActionResult> DeleteTypeOfExpense(Guid id)
        {
            var typeOfExpense = await _mediator.Send(new DeleteTypeOfExpenseCommand(id));
            if (typeOfExpense == null)
            {
                return NotFound();
            }
            return Ok(typeOfExpense);
        }

        [HttpGet("GetAllTypeOfExpense")]
        public async Task<IEnumerable<TypeOfExpenseDetatilsDTO>> GetAllTypeOfExpense()
        {
            var typeOfExpense = await _mediator.Send(new GetAllTypeOfExpenseQuery());
            return typeOfExpense;
        }
    }
}

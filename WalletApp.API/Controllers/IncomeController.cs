using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Client.DTO.Income;
using WalletApp.CommandAndQuery.Income.CreateIncome;
using WalletApp.CommandAndQuery.Income.DeleteIncome;
using WalletApp.CommandAndQuery.Income.GetDecimalIncomeDateBaginDateEnd;
using WalletApp.CommandAndQuery.Income.GetDecimalIncomePerDate;
using WalletApp.CommandAndQuery.Income.GetListIncomePerDate;
using WalletApp.CommandAndQuery.Income.GetListIncomePerDateBaginDateEnd;
using WalletApp.Domain.Authorization;

namespace WalletApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IncomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = MyPolicies.UserShowAndAboveAccess)]
        [HttpPost("AddIncome")]
        public async Task<IActionResult> AddIncome(CreateIncomeDTO request)
        {
            var income = await _mediator.Send(new CreateIncomeCommand(request.TypeIncomeId, request.Amount, request.Comment, request.Date));
            return Created(string.Empty, income);
        }

        [Authorize(Policy = MyPolicies.UserShowAndAboveAccess)]
        [HttpDelete("DeleteIncome/{id}")]
        public async Task<IActionResult> DeleteIncome(Guid id)
        {
            var income = await _mediator.Send(new DeleteIncomeCommand(id));
            if (income == null)
            {
                return NotFound();
            }
            return Created(string.Empty, income);
        }

        [Authorize(Policy = MyPolicies.UserShowAndAboveAccess)]
        [HttpGet("GetAllDecimalToDate/{date}")]
        public async Task<decimal> GetAllDecimaltoDate(DateTime date)
        {
            var incomes = await _mediator.Send(new GetDecimalPerDateQuery(date));
            return incomes;
        }

        [Authorize(Policy = MyPolicies.UserShowAndAboveAccess)]
        [HttpGet("GetAllDecimalToBeginDateEndDate/{beginDate}/{endDate}")]
        public async Task<decimal> GetAllDecimalToBeginDateEndDate(DateTime beginDate, DateTime endDate)
        {
            var incomes = await _mediator.Send(new GetDecimalDateBaginDateEndQuery(beginDate, endDate));
            return incomes;
        }

        [Authorize(Policy = MyPolicies.UserShowAndAboveAccess)]
        [HttpGet("GetListToDate/{date}")]
        public async Task<IEnumerable<IncomeDetailsDTO>> GetListToDate(DateTime date)
        {
            var incomes = await _mediator.Send(new GetListPerDateQuery(date));
            return incomes;
        }

        [Authorize(Policy = MyPolicies.UserShowAndAboveAccess)]
        [HttpGet("GetAllListToBeginDateEndDate/{beginDate}/{endDate}")]
        public async Task<IEnumerable<IncomeDetailsDTO>> GetAllListToBeginDateEndDate(DateTime beginDate, DateTime endDate)
        {
            var incomes = await _mediator.Send(new GetListPerDateBaginDateEndQuery(beginDate, endDate));
            return incomes;
        }
    }
}

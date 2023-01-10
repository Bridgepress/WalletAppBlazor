using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Client.DTO.FlowMoney;
using WalletApp.CommandAndQuery.FlowMoney.CreateFlowMoney;
using WalletApp.CommandAndQuery.FlowMoney.GetDecimalFlowMoneyPerDateBaginDateEnd;
using WalletApp.CommandAndQuery.FlowMoney.GetDecimalFlowMoneyPerDay;
using WalletApp.CommandAndQuery.FlowMoney.GetListFlowMoneyPerDateBaginDateEnd;
using WalletApp.CommandAndQuery.FlowMoney.GetListFlowMoneyPerDay;
using WalletApp.Domain.Authorization;

namespace WalletApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FlowMoneyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlowMoneyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = MyPolicies.UserShowAndAboveAccess)]
        [HttpPost("AddFlowMoney")]
        public async Task<ActionResult<CreateFlowMoneyDTO>> AddFlowMoney(CreateFlowMoneyDTO request)
        {
            var flowMoney = await _mediator.Send(new CreateFlowMoneyCommand(request.TypeOfExpenseId, request.Amount, request.Comment, request.Date));
            return Created(string.Empty, flowMoney);
        }

        [Authorize(Policy = MyPolicies.UserShowAndAboveAccess)]
        [HttpDelete("DeleteFlowMoney/{id}")]
        public async Task<IActionResult> DeleteFlowMoney(Guid id)
        {
            var flowMoney = await _mediator.Send(new DeleteFlowMoneyCommand(id));
            if (flowMoney == null)
            {
                return NotFound();
            }
            return Created(string.Empty, flowMoney);
        }

        [Authorize(Policy = MyPolicies.UserShowAndAboveAccess)]
        [HttpGet("GetAllDecimalToDate/{date}")]
        public async Task<decimal> GetAllDecimaltoDate(DateTime date)
        {
            var flowMoneys = await _mediator.Send(new GetDecimalFlowMoneyPerDayQuery(date));
            return flowMoneys;
        }

        [Authorize(Policy = MyPolicies.UserShowAndAboveAccess)]
        [HttpGet("GetAllDecimalToBeginDateEndDate/{beginDate}/{endDate}")]
        public async Task<decimal> GetAllDecimalToBeginDateEndDate(DateTime beginDate, DateTime endDate)
        {
            var flowMoneys = await _mediator.Send(new GetDecimalPerDateBaginDateEndQuery(beginDate, endDate));
            return flowMoneys;
        }

        [Authorize(Policy = MyPolicies.UserShowAndAboveAccess)]
        [HttpGet("GetListToDate/{date}")]
        public async Task<IEnumerable<FlowMoneyDetailsDTO>> GetListToDate(DateTime date)
        {
            var flowMoneys = await _mediator.Send(new GetListFlowMoneyPerDayQuery(date));
            return flowMoneys;
        }

        [Authorize(Policy = MyPolicies.UserShowAndAboveAccess)]
        [HttpGet("GetAllListToBeginDateEndDate/{beginDate}/{endDate}")]
        public async Task<IEnumerable<FlowMoneyDetailsDTO>> GetAllListToBeginDateEndDate(DateTime beginDate, DateTime endDate)
        {
            var flowMoneys = await _mediator.Send(new GetListPerDateBaginDateEndQuery(beginDate, endDate));
            return flowMoneys;
        }
    }
}

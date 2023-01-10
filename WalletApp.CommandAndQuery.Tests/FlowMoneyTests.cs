using FluentValidation.Results;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WalletApp.Client.DTO.FlowMoney;
using WalletApp.Client.DTO.TypeOfExpense;
using WalletApp.CommandAndQuery.FlowMoney.CreateFlowMoney;
using WalletApp.CommandAndQuery.FlowMoney.GetListFlowMoneyPerDay;
using WalletApp.CommandAndQuery.Income.GetListIncomePerDate;
using WalletApp.CommandAndQuery.TypeOfExpense.CreateTypeOfExpense;
using WalletApp.CommandAndQuery.TypeOfExpense.GetAllTypeOfExpense;
using WalletApp.Domain.DTO.TypeOfExpense;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.Tests
{
    [TestClass]
    public class FlowMoneyTests
    {
        private readonly Mock<ITypeOfExpenseService> _typeOfExpenseMock;
        private readonly Mock<IFlowMoneyService> _flowMoneyServiceMock;
        private readonly Mock<IMediator> _mediatorMock;

        public FlowMoneyTests()
        {
            _typeOfExpenseMock = new();
            _flowMoneyServiceMock = new();
            _mediatorMock = new();
        }

        [TestMethod]
        public async Task CreateTypeOfExpense()
        {
            var command = new CreateTypeOfExpenseCommand("Test");
            _typeOfExpenseMock.Setup(x => x.AddAsync(It.IsAny<TypeOfExpenseDTO>())).ReturnsAsync(new TypeOfExpenseDTO() { Name = "Test" });
            var handler = new CreateTypeOfExpenseCommandHandler(_mediatorMock.Object, _typeOfExpenseMock.Object);
            TypeOfExpenseDTO result = await handler.Handle(command, default);
            Assert.AreEqual(result.Name, "Test");
        }

        [TestMethod]
        public async Task GetAllTypeOfExpense()
        {
            var command = new GetAllTypeOfExpenseQuery();
            _typeOfExpenseMock.Setup(x => x.GetAllEnumerable()).ReturnsAsync(new List<TypeOfExpenseDetatilsDTO>()
            {
                new TypeOfExpenseDetatilsDTO()
                {
                    Id = Guid.NewGuid(),
                    Name = "Test1"
                },
                 new TypeOfExpenseDetatilsDTO()
                {
                    Id = Guid.NewGuid(),
                    Name = "Test2"
                },
                  new TypeOfExpenseDetatilsDTO()
                {
                    Id = Guid.NewGuid(),
                    Name = "Test3"
                }, new TypeOfExpenseDetatilsDTO()
                {
                    Id = Guid.NewGuid(),
                    Name = "Test4"
                },
            });
            var query = new GetAllTypeOfExpenseQueryHandler(_mediatorMock.Object, _typeOfExpenseMock.Object);
            var result = query.Handle(command, default).Result.ToList();
            Assert.AreEqual(result.Count, 4);
        }

        [TestMethod]
        public async Task GetListPerDate()
        {  
            _flowMoneyServiceMock.Setup(x => x.GetListFlowMoneyPerDate(It.IsAny<DateTime>())).ReturnsAsync(new List<FlowMoneyDetailsDTO>()
            {
                new FlowMoneyDetailsDTO()
                {
                  Amount = 2000,
                  Comment = "qqqqq",
                  Date = DateTime.Now,
                  Id = Guid.NewGuid(),
                  TypeOfExpense = "Bar"
                },
                new FlowMoneyDetailsDTO()
                {
                  Amount = 2000,
                  Comment = "qqqqq",
                  Date = DateTime.Now,
                  Id = Guid.NewGuid(),
                  TypeOfExpense = "Bar"
                }
            });
            var command3 = new GetListFlowMoneyPerDayQuery(DateTime.Now);
            var query2 = new GetListFlowMoneyPerDayQueryHandler(_mediatorMock.Object, _flowMoneyServiceMock.Object);
            var result = query2.Handle(command3, default).Result.ToList();
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public async Task CreateFlowMoney()
        {
            _flowMoneyServiceMock.Setup(x => x.AddAsync(It.IsAny<CreateFlowMoneyDTO>())).ReturnsAsync(new CreateFlowMoneyDTO() { Amount = 2000, Comment = "qqqq", Date = DateTime.Now, TypeOfExpenseId = Guid.NewGuid() });
            var command2 = new CreateFlowMoneyCommand(Guid.NewGuid(), 2000, "qqqqq", DateTime.Now);
            var handler = new CreateFlowMoneyCommandHandler(_mediatorMock.Object, _flowMoneyServiceMock.Object);
            var result = await handler.Handle(command2, default);
            Assert.AreEqual(result.Amount, 2000);
        }
    }
}
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Rokkit200TechAssessment.Controllers;
using Rokkit200TechnicalAssessment.Repositories.Interfaces;

namespace AccountService.Tests.Controller
{
    public class AccountControllerTests
    {
        private readonly IAccountService _accService;
        public AccountControllerTests()
        {
            _accService = A.Fake<IAccountService>();
        }

        [Fact]
        public void Should_create_savings_account_ReturnOK() 
        {
            //Arrange
            var id = 1;
            long amount = 10000;
            var controller = new AccountController(_accService);

            //Act
            var result = controller.CreateSavingsAccount(id, amount) as OkObjectResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Should_create_current_account_ReturnOK()
        {
            //Arrange
            var id = 1;
            var controller = new AccountController(_accService);

            //Act
            var result = controller.CreateCurrentAccount(id) as OkObjectResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Deposit_method_should_ReturnOK()
        {
            //Arrange
            var id = 1;
            long amount = 10000;
            var controller = new AccountController(_accService);

            //Act
            var result = controller.Deposit(id, amount) as OkObjectResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Withdraw_method_should_ReturnOK()
        {
            //Arrange
            var id = 1;
            long amount = 10000;
            var controller = new AccountController(_accService);

            //Act
            var result = controller.Withdraw(id, amount) as OkObjectResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}

using Moq;
using Microsoft.AspNetCore.Mvc;
using TDD_Architecture.Controllers.V1.Login;
using TDD_Architecture.Application.Services.Login.Interfaces;
using TDD_Architecture.Domain.Enums;
using TDD_Architecture.Application.Models.Http;

namespace TDD_Architecture.Tests.Controllers.Login
{
    public class LoginControllerTests
    {
        private readonly Mock<ILoginService> _loginServiceMock;
        private readonly LoginController _controller;

        public LoginControllerTests()
        {
            _loginServiceMock = new Mock<ILoginService>();
            _controller = new LoginController(_loginServiceMock.Object);
        }

        [Fact]
        public async Task GetLogin_ReturnsOk_WhenServiceReturnsSuccess()
        {
            // Arrange
            var email = "usertest@test.com.br";
            var result = new Result<string>
            {
                StatusCode = (int)HttpStatus.Ok,
                Data = "token123",
                Message = "Login successfully"
            };

            _loginServiceMock
                .Setup(s => s.GetLogin(email))
                .ReturnsAsync(result);

            // Act
            var response = await _controller.GetLogin(email);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(result, okResult.Value);
        }

        [Fact]
        public async Task GetLogin_ReturnsBadRequest_WhenServiceReturnsBadRequest()
        {
            // Arrange
            var email = "invalid@email.com";
            var result = new Result<string>
            {
                StatusCode = (int)HttpStatus.BadRequest,
                Data = null,
                Message = "Invalid email"
            };

            _loginServiceMock
                .Setup(s => s.GetLogin(email))
                .ReturnsAsync(result);

            // Act
            var response = await _controller.GetLogin(email);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal(result, badRequestResult.Value);
        }
    }
}
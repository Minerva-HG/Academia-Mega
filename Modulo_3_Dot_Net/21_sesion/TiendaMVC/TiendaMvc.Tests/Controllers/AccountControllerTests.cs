using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TiendaMVC.Controllers;
using TiendaMVC.Models;
using TiendaMVC.Services;
using Xunit;

public class AccountControllerTest
{
    [Fact]

    public async Task _Login_InvalidCredentials_ReturnsViewError()
    {
        var mockAPI = new Mock<ApiClient>();
        mockAPI.Setup(s => s.LoginAsync(It.IsAny<User>()))
            .ReturnsAsync(false);

        var accObj = new AccountController(mockAPI.Object);

        var dto = new User { Username = "mihernandezg", Password = "mala" };
        var result = await accObj.Login(dto);

        var view = result.Should().BeOfType<ViewResult>().Subject;
        view.Model.Should().Be(dto);

        accObj.ModelState.IsValid.Should().BeFalse();
        accObj.ModelState[string.Empty].Errors.Should()
            .ContainSingle(e => e.ErrorMessage == "Usuario o contraseña no válidos");
    }
}
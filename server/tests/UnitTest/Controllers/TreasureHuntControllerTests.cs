using API.Controllers.Public;
using Application.Commands.TreasureHunt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class TreasureHuntControllerTests
{
    [Fact]
    public async Task CalculateFuel_ValidRequest_ReturnsOkResult()
    {
        var mockMediator = new Mock<IMediator>();
        mockMediator
            .Setup(m => m.Send(It.IsAny<CalculateFuelCommand>(), default))
            .ReturnsAsync(3.23607);

        var controller = new TreasureHuntController(mockMediator.Object);
        var command = new CalculateFuelCommand
        {
            N = 3,
            M = 3,
            P = 3,
            Matrix = new[]
            {
                new[] { 1, 0, 0 },
                new[] { 0, 2, 0 },
                new[] { 0, 0, 3 }
            }
        };

        var result = await controller.CalculateFuel(command);

        var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
        Xunit.Assert.Equal(3.23607, okResult.Value);
    }

    [Fact]
    public async Task CalculateFuel_InvalidRequest_ReturnsBadRequest()
    {
        var mockMediator = new Mock<IMediator>();
        var controller = new TreasureHuntController(mockMediator.Object);

        controller.ModelState.AddModelError("Matrix", "Matrix is required");

        var command = new CalculateFuelCommand
        {
            N = 0,
            M = 0,
            P = 0,
            Matrix = null
        };

        var result = await controller.CalculateFuel(command);

        Xunit.Assert.IsType<BadRequestObjectResult>(result);
    }
}

using Application.Commands.TreasureHuntHandlers;
using Domain;
using Application.Commands.TreasureHunt;
using Domain.IRepositories;
using Moq;
using Xunit;

public class CalculateFuelCommandHandlerTests
{
    [Fact]
    public async Task Handle_ValidInput_ReturnsCorrectFuel()
    {
        var mockRepository = new Mock<ITreasureHuntRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        var handler = new CalculateFuelCommandHandler(mockRepository.Object, mockUnitOfWork.Object);
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

        var result = await handler.Handle(command, CancellationToken.None);

        Xunit.Assert.Equal(3.23607, result, 5);
    }

    [Fact]
    public async Task Handle_NullCommand_ThrowsArgumentNullException()
    {
        var mockRepository = new Mock<ITreasureHuntRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        var handler = new CalculateFuelCommandHandler(mockRepository.Object, mockUnitOfWork.Object);

        await Xunit.Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(null, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_InvalidMatrix_ThrowsInvalidOperationException()
    {
        var mockRepository = new Mock<ITreasureHuntRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        var handler = new CalculateFuelCommandHandler(mockRepository.Object, mockUnitOfWork.Object);
        var command = new CalculateFuelCommand
        {
            N = 2,
            M = 2,
            P = 3,
            Matrix = new[]
            {
                new[] { 1, 0 },
                new[] { 0, 2 }
                // Missing chest 3
            }
        };

        await Xunit.Assert.ThrowsAsync<InvalidOperationException>(() => handler.Handle(command, CancellationToken.None));
    }
}

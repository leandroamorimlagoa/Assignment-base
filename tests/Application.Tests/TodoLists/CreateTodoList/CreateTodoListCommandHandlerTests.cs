using Assignment.Application.Common.Interfaces;
using Assignment.Application.TodoLists.Commands.CreateTodoList;
using Assignment.Domain.Entities;
using MediatR;
using Moq;

namespace Application.Tests.TodoLists.CreateTodoList;
[TestFixture]
public class CreateTodoListCommandHandlerTests
{
    private Mock<IApplicationDbContext> _mockDbContext;
    private IRequestHandler<CreateTodoListCommand, int> _handler;

    [SetUp]
    public void SetUp()
    {
        var expectedId = 1;
        _mockDbContext = new Mock<IApplicationDbContext>();

        _mockDbContext.Setup(db => db.TodoLists.Add(It.IsAny<TodoList>())).Verifiable();
        _mockDbContext.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(expectedId);

        _handler = new CreateTodoListCommandHandler(_mockDbContext.Object);
    }

    [Test]
    public async Task Handle_ShouldCreateTodoList()
    {
        // Arrange
        var command = new CreateTodoListCommand("Test Todo List");

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        _mockDbContext.Verify(db => db.TodoLists.Add(It.IsAny<TodoList>()), Times.Once);
        _mockDbContext.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}

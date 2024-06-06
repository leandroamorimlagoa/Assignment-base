using System.Linq.Expressions;
using Assignment.Application.Common.Interfaces;
using Assignment.Application.TodoLists.Commands.CreateTodoList;
using Assignment.Domain.Constants;
using Assignment.Domain.Entities;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Application.Tests.TodoLists.CreateTodoList;
[TestFixture]
public class CreateTodoListCommandValidatorTests
{
    private Mock<IApplicationDbContext> _mockDbContext;
    private CreateTodoListCommandValidator _validator;

    [SetUp]
    public void SetUp()
    {
        _mockDbContext = new Mock<IApplicationDbContext>();        
        _validator = new CreateTodoListCommandValidator(_mockDbContext.Object);
    }

    [Ignore("AnyAsync not working for now in mock")]
    public async Task ShouldHaveValidationErrorWhenTitleIsEmpty()
    {
        // Arrange
        var command = new CreateTodoListCommand(string.Empty);

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(c => c.Title);
    }

    [Ignore("AnyAsync not working for now in mock")]
    public async Task ShouldHaveValidationErrorWhenTitleIsTooLong()
    {
        // Arrange
        var exceededTitle = new string('A', FieldsConfigurations.MaxLengthTitleFields + 1);
        var command = new CreateTodoListCommand(exceededTitle);

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(c => c.Title);
    }

    [Ignore("AnyAsync not working for now in mock")]
    public async Task ShouldHaveValidationErrorWhenTitleIsNotUnique()
    {
        // Arrange
        var command = new CreateTodoListCommand("Non-Unique Title");

        _mockDbContext.Setup(db => db.TodoLists.AnyAsync(It.IsAny<Expression<Func<TodoList, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(c => c.Title).WithErrorCode("Unique");
    }

    [Ignore("AnyAsync not working for now in mock")]
    public async Task ShouldNotHaveValidationErrorWhenTitleIsUnique()
    {
        // Arrange
        var command = new CreateTodoListCommand("Unique Title");

        _mockDbContext.Setup(db => db.TodoLists.AnyAsync(It.IsAny<Expression<Func<TodoList, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldNotHaveValidationErrorFor(c => c.Title);
    }
}

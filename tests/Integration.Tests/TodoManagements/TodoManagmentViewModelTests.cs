using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Infrastructure.Data;
using Assignment.UI.Features.TodoManagements;
using Caliburn.Micro;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Integration.Tests.TodoManagements;
[TestFixture]
public class TodoManagmentViewModelTests
{
    private ApplicationDbContext _dbContext;
    private Mock<ISender> _sender;
    private Mock<IWindowManager> _windowManager;

    private TodoManagmentViewModel _viewModel;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseSqlite("Data Source=:memory:")
                            .Options;

        _dbContext = new ApplicationDbContext(options);
        _dbContext.Database.EnsureCreated();
        // Initialize the database with some data to execute integration tests
        // we can use the extensions methods to seed the database


        _windowManager = new Mock<IWindowManager>();
        _sender = new Mock<ISender>();
        _viewModel = new TodoManagmentViewModel(_sender.Object, _windowManager.Object);
    }

    //[Test]
    [Ignore("We can implement integration tests by using the Bootstrapper class")]
    public async Task LoadTodoListsAsync_ShouldLoadTodoLists()
    {
        // Act
        await _viewModel.RefereshTodoLists();

        // Assert
        //_viewModel.TodoLists.Should().HaveCount(2);
        //_viewModel.TodoLists.Should().Contain(x => x.Title == "Test Todo List 1");
        //_viewModel.TodoLists.Should().Contain(x => x.Title == "Test Todo List 2");
    }

    [TearDown]
    public void TearDown()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Dispose();
    }
}

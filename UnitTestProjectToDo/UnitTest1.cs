using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToDoListApp.Controllers;
using ToDoListApp.Models;
using ToDoListApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestProjectToDo
{
    [TestClass]
    public class UnitTest1
    {

        private Mock<ITodoservices> _mockService;
        private ToDoController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockService = new Mock<ITodoservices>();
            _controller = new ToDoController(_mockService.Object);
        }

        [TestMethod] // GetAll
    
        public void TestMethod1()
        {
            // Arrange
            string error = "";
            _mockService.Setup(s => s.AddNewToDo("Test New", ref error)).Returns(true);
            _mockService.Setup(s => s.GetToDoList()).Returns(new List<TodoModel>
    {
        new TodoModel { Id = Guid.NewGuid(), Title = "Test New", IsCompleted = false }
    });

            // Act
            var addResult = _controller.AddNewToDo(new RequestBody { Title = "Test New" });
            var getResult = _controller.GetAll();

            // Assert
            Assert.IsNotNull(addResult);
            Assert.IsNotNull(getResult);
        }
    }
}

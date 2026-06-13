using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToDoListApp.Controllers;
using ToDoListApp.Services;

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

        }
    }
}

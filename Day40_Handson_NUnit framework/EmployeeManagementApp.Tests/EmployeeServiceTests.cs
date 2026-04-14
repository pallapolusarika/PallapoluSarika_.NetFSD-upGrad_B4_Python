using NUnit.Framework;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Services;
using System;

namespace EmployeeManagementApp.Tests
{
    public class EmployeeServiceTests
    {
        private EmployeeService _employeeService;

        [SetUp]
        public void Setup()
        {
            _employeeService = new EmployeeService();
        }

        [Test]
        public void CalculateSalary_ValidSalary_ReturnsCorrectSalary()
        {
            double result = _employeeService.CalculateSalary(10000);
            Assert.AreEqual(13000, result);
        }

        [Test]
        public void CalculateSalary_InvalidSalary_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _employeeService.CalculateSalary(-1000));
        }

        [Test]
        public void Withdraw_ValidAmount_ReturnsRemainingBalance()
        {
            double result = _employeeService.Withdraw(10000, 2000);
            Assert.AreEqual(8000, result);
        }

        [Test]
        public void Withdraw_InsufficientBalance_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _employeeService.Withdraw(1000, 2000));
        }

        [Test]
        public void AddEmployee_ValidEmployee_ReturnsSuccessMessage()
        {
            var employee = new Employee
            {
                Id = 1,
                Name = "Rishitha",
                BasicSalary = 15000
            };

            string result = _employeeService.AddEmployee(employee);

            Assert.AreEqual("Employee added successfully", result);
        }

        [Test]
        public void AddEmployee_NullEmployee_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _employeeService.AddEmployee(null));
        }

        [Test]
        public void AddEmployee_EmptyName_ThrowsArgumentException()
        {
            var employee = new Employee
            {
                Id = 2,
                Name = "",
                BasicSalary = 15000
            };

            Assert.Throws<ArgumentException>(() => _employeeService.AddEmployee(employee));
        }

        [Test]
        public void AddEmployee_ZeroSalary_ThrowsArgumentException()
        {
            var employee = new Employee
            {
                Id = 3,
                Name = "Test",
                BasicSalary = 0
            };

            Assert.Throws<ArgumentException>(() => _employeeService.AddEmployee(employee));
        }
    }
}
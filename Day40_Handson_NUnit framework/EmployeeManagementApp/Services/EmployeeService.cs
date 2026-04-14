using EmployeeManagementApp.Models;
using System;

namespace EmployeeManagementApp.Services
{
    public class EmployeeService
    {
        public string AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (string.IsNullOrWhiteSpace(employee.Name))
                throw new ArgumentException("Employee name cannot be empty.");

            if (employee.BasicSalary <= 0)
                throw new ArgumentException("Basic salary must be greater than zero.");

            return "Employee added successfully";
        }

        public double CalculateSalary(double basicSalary)
        {
            if (basicSalary <= 0)
                throw new ArgumentException("Basic salary must be greater than zero.");

            double hra = basicSalary * 0.20;
            double da = basicSalary * 0.10;

            return basicSalary + hra + da;
        }

        public double Withdraw(double balance, double withdrawAmount)
        {
            if (withdrawAmount <= 0)
                throw new ArgumentException("Withdraw amount must be greater than zero.");

            if (withdrawAmount > balance)
                throw new InvalidOperationException("Insufficient balance.");

            return balance - withdrawAmount;
        }
    }
}
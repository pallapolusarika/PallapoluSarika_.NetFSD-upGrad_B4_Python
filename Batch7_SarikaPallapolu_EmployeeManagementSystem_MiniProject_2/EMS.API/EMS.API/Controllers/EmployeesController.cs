using EMS.API.Data;
using EMS.API.DTOs;
using EMS.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> GetAll([FromQuery] EmployeeQueryParams query)
        {
            var employeesQuery = _context.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                var term = query.Search.Trim().ToLower();
                employeesQuery = employeesQuery.Where(e =>
                    (e.FirstName + " " + e.LastName).ToLower().Contains(term) ||
                    e.Email.ToLower().Contains(term));
            }

            if (!string.IsNullOrWhiteSpace(query.Department))
            {
                employeesQuery = employeesQuery.Where(e => e.Department == query.Department);
            }

            if (!string.IsNullOrWhiteSpace(query.Status))
            {
                employeesQuery = employeesQuery.Where(e => e.Status == query.Status);
            }

            employeesQuery = query.SortBy.ToLower() switch
            {
                "salary" => query.SortDir.ToLower() == "desc"
                    ? employeesQuery.OrderByDescending(e => e.Salary)
                    : employeesQuery.OrderBy(e => e.Salary),

                "joindate" => query.SortDir.ToLower() == "desc"
                    ? employeesQuery.OrderByDescending(e => e.JoinDate)
                    : employeesQuery.OrderBy(e => e.JoinDate),

                _ => query.SortDir.ToLower() == "desc"
                    ? employeesQuery.OrderByDescending(e => e.LastName).ThenByDescending(e => e.FirstName)
                    : employeesQuery.OrderBy(e => e.LastName).ThenBy(e => e.FirstName)
            };

            query.Page = query.Page < 1 ? 1 : query.Page;
            query.PageSize = query.PageSize < 1 ? 10 : Math.Min(query.PageSize, 100);

            var totalCount = await employeesQuery.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)query.PageSize);

            var data = await employeesQuery
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(e => new EmployeeResponseDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Phone = e.Phone,
                    Department = e.Department,
                    Designation = e.Designation,
                    Salary = e.Salary,
                    JoinDate = e.JoinDate,
                    Status = e.Status
                })
                .ToListAsync();

            var result = new PagedResult<EmployeeResponseDto>
            {
                Data = data,
                TotalCount = totalCount,
                Page = query.Page,
                PageSize = query.PageSize,
                TotalPages = totalPages,
                HasNextPage = query.Page < totalPages,
                HasPrevPage = query.Page > 1
            };

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> GetById(int id)
        {
            var e = await _context.Employees.FindAsync(id);
            if (e == null) return NotFound();

            return Ok(new EmployeeResponseDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Phone = e.Phone,
                Department = e.Department,
                Designation = e.Designation,
                Salary = e.Salary,
                JoinDate = e.JoinDate,
                Status = e.Status
            });
        }

        [HttpGet("dashboard")]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> GetDashboard()
        {
            var total = await _context.Employees.CountAsync();
            var active = await _context.Employees.CountAsync(e => e.Status == "Active");
            var inactive = await _context.Employees.CountAsync(e => e.Status == "Inactive");
            var departments = await _context.Employees.Select(e => e.Department).Distinct().CountAsync();

            var breakdown = await _context.Employees
                .GroupBy(e => e.Department)
                .Select(g => new DepartmentCountDto
                {
                    Department = g.Key,
                    Count = g.Count()
                })
                .OrderBy(x => x.Department)
                .ToListAsync();

            var recent = await _context.Employees
                .OrderByDescending(e => e.CreatedAt)
                .ThenByDescending(e => e.Id)
                .Take(5)
                .Select(e => new EmployeeResponseDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Phone = e.Phone,
                    Department = e.Department,
                    Designation = e.Designation,
                    Salary = e.Salary,
                    JoinDate = e.JoinDate,
                    Status = e.Status
                })
                .ToListAsync();

            return Ok(new DashboardSummaryDto
            {
                TotalEmployees = total,
                ActiveEmployees = active,
                InactiveEmployees = inactive,
                TotalDepartments = departments,
                DepartmentBreakdown = breakdown,
                RecentEmployees = recent
            });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(EmployeeRequestDto dto)
        {
            var emailExists = await _context.Employees.AnyAsync(e => e.Email == dto.Email);
            if (emailExists)
            {
                return Conflict(new { message = "Email already exists." });
            }

            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                Department = dto.Department,
                Designation = dto.Designation,
                Salary = dto.Salary,
                JoinDate = dto.JoinDate,
                Status = dto.Status,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, new EmployeeResponseDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
                Department = employee.Department,
                Designation = employee.Designation,
                Salary = employee.Salary,
                JoinDate = employee.JoinDate,
                Status = employee.Status
            });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, EmployeeRequestDto dto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            var emailExists = await _context.Employees.AnyAsync(e => e.Email == dto.Email && e.Id != id);
            if (emailExists)
            {
                return Conflict(new { message = "Email already exists." });
            }

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.Phone = dto.Phone;
            employee.Department = dto.Department;
            employee.Designation = dto.Designation;
            employee.Salary = dto.Salary;
            employee.JoinDate = dto.JoinDate;
            employee.Status = dto.Status;
            employee.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new EmployeeResponseDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
                Department = employee.Department,
                Designation = employee.Designation,
                Salary = employee.Salary,
                JoinDate = employee.JoinDate,
                Status = employee.Status
            });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Employee deleted successfully." });
        }
    }
}
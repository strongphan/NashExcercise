using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace ManhPT.EF_Core_Assignment_1.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly BusinessContext _dbContext;

        public EmployeeRepository(BusinessContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Employee>> GetListEmployeeWithDepartmentAsync()
        {
            var employeesWithDepartments = await _dbContext.Employees
                .Include(e => e.Department)
                .ToListAsync();

            return employeesWithDepartments;
        }
        public async Task<IEnumerable<Employee>> GetEmployeesWithProjectsAsync()
        {
            var employeesWithProjects = await (from emp in _dbContext.Employees
                                               join pe in _dbContext.ProjectEmployees on emp.Id equals pe.EmployeeId into projectEmployees
                                               from pe in projectEmployees.DefaultIfEmpty()
                                               select new Employee
                                               {
                                                   Id = emp.Id,
                                                   Name = emp.Name,
                                                   DepartmentId = emp.DepartmentId,
                                                   JoinedDate = emp.JoinedDate,
                                                   Department = emp.Department,
                                                   ProjectEmployees = emp.ProjectEmployees,
                                               }).ToListAsync();
            return employeesWithProjects;
        }
        public async Task<IEnumerable<Employee>> GetFilterEmployeesAsync()
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var filteredEmployees = await _dbContext.Employees
                    .FromSqlRaw("SELECT e.Id, e.Name, e.DepartmentId,e.JoinedDate FROM Employees e INNER JOIN Salary s ON e.Id = s.EmployeeId WHERE s.Amount > 100 AND e.JoinedDate >= '2024-01-01';")
                    .ToListAsync();


                await _dbContext.SaveChangesAsync();

                transaction.Commit();

                return filteredEmployees;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}

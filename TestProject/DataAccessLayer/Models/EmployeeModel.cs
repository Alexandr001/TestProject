using System.Diagnostics.CodeAnalysis;
using TestProject.Models;

namespace TestProject.DataAccessLayer.Models
{
    public class EmployeeModel
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public int CompanyId { get; set; }
        public string PassportNumber { get; set; }
        public string DepartamentName { get; set; }
    }
}

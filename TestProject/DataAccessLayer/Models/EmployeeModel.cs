using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TestProject.Models;

namespace TestProject.DataAccessLayer.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        [Phone]
        [StringLength(12, MinimumLength = 12)]
        public string? Phone { get; set; }
        [Range(1, int.MaxValue)]
        public int? CompanyId { get; set; }
        public string? DepartmentName { get; set; }
        [StringLength(11, MinimumLength = 9)]
        public string? PassportNumber { get; set; }
        
    }
}

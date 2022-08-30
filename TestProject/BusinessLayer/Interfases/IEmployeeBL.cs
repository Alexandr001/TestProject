using TestProject.DataAccessLayer.Models;

namespace TestProject.BusinessLayer.Interfases
{
    public interface IEmployeeBL
    {
        int CreateEmployee(EmployeeModel model);
        void DeleteEmployee(int id);
        IEnumerable<EmployeeModel> GetEmployeesByIdCompany(int idCompany);
        IEnumerable<EmployeeModel> GetEmployeeByDepartment(string departmentName);
        void UpdateEmployee(int id, params object[] param);
    }
}

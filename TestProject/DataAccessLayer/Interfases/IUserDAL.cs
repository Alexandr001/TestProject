using TestProject.DataAccessLayer.Models;

namespace TestProject.DataAccessLayer.Interfases
{
    public interface IUserDAL
    {
        int CreateEmployee(EmployeeModel model);
        void DeleteEmployee(int id);
        List<EmployeeModel> GetEmployeesByIdCompany(int idCompany);
        List<EmployeeModel> GetEmployeeByDepartment(int idDepartment);
        void UpdateEmployee(int id, params object[] param);
    }
}

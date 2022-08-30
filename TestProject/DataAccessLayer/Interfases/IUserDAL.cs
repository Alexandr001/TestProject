using TestProject.DataAccessLayer.Models;

namespace TestProject.DataAccessLayer.Interfases
{
    public interface IUserDAL
    {
        int CreateEmployee(EmployeeModel model);
        void DeleteEmployee(int id);
        IEnumerable<EmployeeModel> GetEmployeesByIdCompany(int idCompany);
        IEnumerable<EmployeeModel> GetEmployeeByDepartment(string nameDepartment);
        void UpdateEmployee(int id, params object[] param);
    }
}

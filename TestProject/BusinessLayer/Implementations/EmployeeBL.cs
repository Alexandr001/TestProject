using TestProject.BusinessLayer.Interfases;
using TestProject.DataAccessLayer.Interfases;
using TestProject.DataAccessLayer.Models;

namespace TestProject.BusinessLayer.Implementations
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeDAL _userDAL;

        public EmployeeBL(IEmployeeDAL userDAL)
        {
            _userDAL = userDAL;
        }


        public int CreateEmployee(EmployeeModel model) 
            => _userDAL.CreateEmployee(model);

        public void DeleteEmployee(int id) 
            => _userDAL.DeleteEmployee(id);

        public IEnumerable<EmployeeModel> GetEmployeeByDepartment(string departmentName)
            => _userDAL.GetEmployeeByDepartment(departmentName);

        public IEnumerable<EmployeeModel> GetEmployeesByIdCompany(int idCompany)
            => _userDAL.GetEmployeesByIdCompany(idCompany);

        public void UpdateEmployee(int id, EmployeeModel model)
            => _userDAL.UpdateEmployee(id, model);
    }
}

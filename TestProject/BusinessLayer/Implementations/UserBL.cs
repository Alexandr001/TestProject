using TestProject.BusinessLayer.Interfases;
using TestProject.DataAccessLayer.Interfases;
using TestProject.DataAccessLayer.Models;

namespace TestProject.BusinessLayer.Implementations
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAL _userDAL;

        public UserBL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public int CreateEmployee(EmployeeModel model) 
            => _userDAL.CreateEmployee(model);

        public void DeleteEmployee(int id) 
            => _userDAL.DeleteEmployee(id);

        public List<EmployeeModel> GetEmployeeByDepartment(int idDepartment)
            => _userDAL.GetEmployeeByDepartment(idDepartment);

        public List<EmployeeModel> GetEmployeesByIdCompany(int idCompany)
            => _userDAL.GetEmployeesByIdCompany(idCompany);

        public void UpdateEmployee(int id, params object[] param)
            => _userDAL.UpdateEmployee(id, param);
    }
}

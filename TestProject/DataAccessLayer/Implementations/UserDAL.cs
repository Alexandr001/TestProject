using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using TestProject.DataAccessLayer.Interfases;
using TestProject.DataAccessLayer.Models;

namespace TestProject.DataAccessLayer.Implementations
{
    public class UserDAL : IUserDAL
    {
        public int CreateEmployee(EmployeeModel model)
        {
            EmployeeModel? employeeModel;
            using (SqlConnection connection = DBConnection.CreateConnection())
            {
                employeeModel = connection.Query<EmployeeModel>(
                    $"INSERT INTO {DBTableNames.Employee} " +
                    $"({nameof(EmployeeModel.Name)}, " +
                    $"{nameof(EmployeeModel.Surname)}, " +
                    $"{nameof(EmployeeModel.Phone)}, " +
                    $"{nameof(EmployeeModel.CompanyId)}, " +
                    $"{nameof(EmployeeModel.PassportNumber)}, " +
                    $"{nameof(EmployeeModel.DepartamentName)}) " +
                    $"VALUES" +
                    $"(@{nameof(EmployeeModel.Name)}, " +
                    $"@{nameof(EmployeeModel.Surname)}, " +
                    $"@{nameof(EmployeeModel.Phone)}, " +
                    $"@{nameof(EmployeeModel.CompanyId)}, " +
                    $"@{nameof(EmployeeModel.PassportNumber)}, " +
                    $"@{nameof(EmployeeModel.DepartamentName)})", new { model }).FirstOrDefault();
            }
            return employeeModel.Id;
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection connection = DBConnection.CreateConnection())
            {
                var sqlQuery = $"DELETE FROM {DBTableNames.Employee} WHERE {nameof(EmployeeModel.Id)} = @id";
                connection.Execute(sqlQuery, new { id });
            }
        }

        public IEnumerable<EmployeeModel> GetEmployeeByDepartment(int nameDepartment)
        {
            using (SqlConnection connection = DBConnection.CreateConnection())
            {
                return connection.Query<EmployeeModel>($"SELECT * FROM {DBTableNames.Employee} WHERE {nameof(EmployeeModel.DepartamentName)} = @nameDepartment", new { nameDepartment });
            }
        }

        public IEnumerable<EmployeeModel> GetEmployeesByIdCompany(int idCompany)
        {
            using (SqlConnection connection = DBConnection.CreateConnection())
            {
                return connection.Query<EmployeeModel>($"SELECT * FROM {DBTableNames.Employee} WHERE {nameof(EmployeeModel.CompanyId)} = @id", new { id = idCompany });
            }
        }

        public void UpdateEmployee(int id, params object[] param)
        {
            
        }
    }
}

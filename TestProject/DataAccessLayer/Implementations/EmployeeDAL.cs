using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Text;
using TestProject.DataAccessLayer.Interfases;
using TestProject.DataAccessLayer.Models;

namespace TestProject.DataAccessLayer.Implementations
{
    public class EmployeeDAL : IEmployeeDAL
    {
        public int CreateEmployee(EmployeeModel model)
        {
            int id;
            using (SqlConnection connection = DBConnection.CreateConnection())
            {
                id = connection.Query<int>(
                    $"INSERT INTO {DBTableNames.Employee} " +
                    "OUTPUT INSERTED.Id " +
                    $"VALUES " +
                    $"(@{nameof(model.Name)}, " +
                    $"@{nameof(model.Surname)}, " +
                    $"@{nameof(model.Phone)}, " +
                    $"@{nameof(model.CompanyId)}, " +
                    $"@{nameof(model.DepartmentName)}, " +
                    $"@{nameof(model.PassportNumber)});",
                    model).FirstOrDefault();
            }
            return id;
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection connection = DBConnection.CreateConnection())
            {
                const string SQL_QUERY = $"DELETE FROM {DBTableNames.Employee} WHERE {nameof(EmployeeModel.Id)} = @id";
                connection.Execute(SQL_QUERY, new { id });
            }
        }

        public IEnumerable<EmployeeModel> GetEmployeeByDepartment(string name)
        {
            using (SqlConnection connection = DBConnection.CreateConnection())
            {
                return connection.Query<EmployeeModel>($"SELECT * FROM {DBTableNames.Employee} WHERE {nameof(EmployeeModel.DepartmentName)} = @nameDepartment",
                                                        new { nameDepartment = name });
            }
        }

        public IEnumerable<EmployeeModel> GetEmployeesByIdCompany(int idCompany)
        {
            using (SqlConnection connection = DBConnection.CreateConnection())
            {
                return connection.Query<EmployeeModel>($"SELECT * FROM {DBTableNames.Employee} WHERE {nameof(EmployeeModel.CompanyId)} = @id", new { id = idCompany });
            }
        }

        public void UpdateEmployee(int id, EmployeeModel model)
        {

            using (SqlConnection connection = DBConnection.CreateConnection())
            {
                string SQL_QUERU = $"UPDATE {DBTableNames.Employee} SET {FiltrationModel(model)} WHERE {nameof(model.Id)} = @id";
                connection.Execute(SQL_QUERU, new { id });
            }
        }


        private string FiltrationModel(EmployeeModel model)
        {
            string str = "";
            
            foreach (var property in model.GetType().GetProperties())
            {
                if (property.Name == nameof(model.Id)) {
                    continue;
                }
                if (property.GetValue(model) == null) {
                    continue;
                }

                str += $" {property.Name} = '{property.GetValue(model)}',";
            }
            str = str.Remove(str.Length - 1);

            return str;
        }
    }
}

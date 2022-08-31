using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
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
            if (model.Name != null)
            {
                str += $"{nameof(model.Name)} = {model.Name},";
            }
            if (model.Surname != null)
            {
                str += $"{nameof(model.Surname)} = {model.Surname},";
            }
            if (model.Phone != null)
            {
                str += $"{nameof(model.Phone)} = {model.Phone},";
            }
            if (model.CompanyId != null)
            {
                str += $"{nameof(model.CompanyId)} = {model.CompanyId},";
            }
            if (model.DepartmentName != null)
            {
                str += $"{nameof(model.DepartmentName)} = {model.DepartmentName},";
            }
            if (model.PassportNumber != null)
            {
                str += $"{nameof(model.PassportNumber)} = {model.PassportNumber},";
            }
            str = str.Remove(str.Length - 1);
            return str;
        }
    }
}

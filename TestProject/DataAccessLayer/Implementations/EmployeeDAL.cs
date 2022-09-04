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
            string SQL_QUERY = $"INSERT INTO {DBTableNames.Employee} OUTPUT INSERTED.Id VALUES ({CreateValuesForMethodCreate(model)})";
            int id;
            using (SqlConnection connection = DBConnection.CreateConnection())
            {

                id = connection.Query<int>( SQL_QUERY, model).FirstOrDefault();   
            }
            return id;
        }

        private string CreateValuesForMethodCreate(EmployeeModel model)
        {
            string str = "";
            foreach (var property in model.GetType().GetProperties())
            {
                if (property.Name == nameof(model.Id))
                {
                    continue;
                }
                if (property.Name == nameof(model.DepartmentName))
                {
                    str += $" (SELECT [Name] FROM {DBTableNames.Department} WHERE {DBTableNames.Department}.[Name] = @{property.Name}),";
                    continue;
                }


                str += $" @{property.Name},";
            }
            str = DeleteLastSymbol(str);
            return str;
        }

        public void DeleteEmployee(int id)
        {
            const string SQL_QUERY = $"DELETE FROM {DBTableNames.Employee} WHERE {nameof(EmployeeModel.Id)} = @id";
            using (SqlConnection connection = DBConnection.CreateConnection())
            {
                connection.Execute(SQL_QUERY, new { id });
            }
        }

        public IEnumerable<EmployeeModel> GetEmployeeByDepartment(string name)
        {
            const string SQL_QUERY = $"SELECT * FROM {DBTableNames.Employee} WHERE {nameof(EmployeeModel.DepartmentName)} = @nameDepartment";
            using (SqlConnection connection = DBConnection.CreateConnection())
            {
                return connection.Query<EmployeeModel>(SQL_QUERY, new { nameDepartment = name });
            }
        }

        public IEnumerable<EmployeeModel> GetEmployeesByIdCompany(int idCompany)
        {
            const string SQL_QUERY = $"SELECT * FROM {DBTableNames.Employee} WHERE {nameof(EmployeeModel.CompanyId)} = @id";
            using (SqlConnection connection = DBConnection.CreateConnection())
            {
                return connection.Query<EmployeeModel>(SQL_QUERY, new { id = idCompany });
            }
        }

        public void UpdateEmployee(int id, EmployeeModel model)
        {
            string SQL_QUERU = $"UPDATE {DBTableNames.Employee} SET {FiltrationModel(model)} WHERE {nameof(model.Id)} = @id";
            using (SqlConnection connection = DBConnection.CreateConnection())
            {
                connection.Execute(SQL_QUERU, new { id });
            }
        }
        private string FiltrationModel(EmployeeModel model)
        {
            string str = "";

            foreach (var property in model.GetType().GetProperties())
            {
                if (property.Name == nameof(model.Id))
                {
                    continue;
                }
                if (property.GetValue(model) == null)
                {
                    continue;
                }

                str += $" {property.Name} = '{property.GetValue(model)}',";
            }
            str = DeleteLastSymbol(str);

            return str;
        }

        private string DeleteLastSymbol(string str)
        { 
            return str.Remove(str.Length - 1); ;
        }
    }
}

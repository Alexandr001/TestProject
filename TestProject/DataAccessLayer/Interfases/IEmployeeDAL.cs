﻿using TestProject.DataAccessLayer.Models;

namespace TestProject.DataAccessLayer.Interfases
{
    public interface IEmployeeDAL
    {
        int CreateEmployee(EmployeeModel model);
        void DeleteEmployee(int id);
        IEnumerable<EmployeeModel> GetEmployeesByIdCompany(int idCompany);
        IEnumerable<EmployeeModel> GetEmployeeByDepartment(int idDepartment);
        void UpdateEmployee(int id, params object[] param);
    }
}
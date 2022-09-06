﻿using TestProject.BusinessLayer.Interfases;
using TestProject.DataAccessLayer.Interfases;
using TestProject.DataAccessLayer.Models;

namespace TestProject.BusinessLayer.Implementations
{
    public class EmployeeBl : IEmployeeBl
    {
        private readonly IEmployeeDal _userDal;
        public EmployeeBl(IEmployeeDal userDal)
        {
            _userDal = userDal;
        }
        public int CreateEmployee(EmployeeModel model)
        {
            Validation.ValidationModel(model);
            return _userDal.CreateEmployee(model);;
        }

        public void DeleteEmployee(int id)
        {
            IdVerification(id);
            _userDal.DeleteEmployee(id);
        }

        public IEnumerable<EmployeeModel> GetEmployeeByDepartment(string departmentName)
        {
            return _userDal.GetEmployeeByDepartment(departmentName);
        }

        public IEnumerable<EmployeeModel> GetEmployeesByIdCompany(int idCompany)
        {
            IdVerification(idCompany);
            return _userDal.GetEmployeesByIdCompany(idCompany);
        }

        public void UpdateEmployee(int id, EmployeeModel model)
        {
            IdVerification(id);
            Validation.ValidationModel(model);
            _userDal.UpdateEmployee(id, model);
        }
        private void IdVerification(int id)
        {
            const int MIN_VALUE_ID = 1;
            if (id < MIN_VALUE_ID) {
                throw new Exception("ID cannot be less than 1!");
            }
        }
    }
}

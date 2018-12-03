using FullStackApp.Core.Business;
using FullStackApp.Core.Interface;
using FullStackApp.Infrastructure.Entities;
using FullStackApp.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackApp.Core.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private IDataRepository _db;
        public EmployeeManager(IDataRepository db)
        {
            _db = db;
        }

        public Operation<EmployeeModel> CreateEmployee(EmployeeModel model)
        {
            return Operation.Create(() =>
            {
                var isExist = _db.Query<Employee>().Where(e => e.EmployeeId == model.EmployeeId);
                if (isExist != null) throw new Exception("employee already exist");

                var entity = model.Create(model);
                _db.Add(entity);
                _db.SaveChanges();
                return model;
            });
        }

        public Operation UpdateEmployee(EmployeeModel model)
        {
            return Operation.Create(() =>
            {
                var ementity = _db.Query<Employee>().Where(e => e.EmployeeId == model.EmployeeId).FirstOrDefault();
                if (ementity == null) throw new Exception($"{model.EmployeeId} Empolyee does not exist");

                var entity = model.Edit(ementity, model);
                _db.Update(entity);
                var result = _db.SaveChanges();
                if (result.Succeeded == false)
                {
                    throw new Exception(result.Message);
                }
                return model;
            });
        }
        public Operation<EmployeeModel[]> GetEmployees()
        {
            return Operation.Create(() =>
            {
                var entities = _db.Query<Employee>().ToList();

                var models = entities.Select(e => new EmployeeModel(e)).ToArray();
                return models;
            });
        }
        public Operation<EmployeeModel> GetEmployeeById(int employeeId)
        {
            return Operation.Create(() =>
            {
                var entity = _db.Query<Employee>().Where(e => e.EmployeeId == employeeId).FirstOrDefault();
                if (entity == null) throw new Exception("employee is not valid ");
                return new EmployeeModel(entity);
            });
        }
        public Operation DeleteEmployee(int id)
        {
            return Operation.Create(() =>
            {
                var entity = _db.Query<Employee>().Where(e => e.EmployeeId == id).FirstOrDefault();
                if (entity == null) throw new Exception("employee does not exist");

                _db.Delete(entity);
                _db.SaveChanges();
            });
        }
    }
}

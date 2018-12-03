using FullStackApp.Core.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackApp.Core.Interface
{
    public interface IEmployeeManager
    {
        Operation<EmployeeModel> CreateEmployee(EmployeeModel model);
        Operation UpdateEmployee(EmployeeModel model);
        Operation<EmployeeModel[]> GetEmployees();
        Operation<EmployeeModel> GetEmployeeById(int employeeId);
        Operation DeleteEmployee(int id);
    }
}

using C_App.DAL;
using C_App.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_App.BAL
{
    internal class EmployeeBAL
    {
        EmployeeDAL dal = new EmployeeDAL();
        public List<EmployeeBEL> ReadCustomer()
        {
            List<EmployeeBEL> lstCus = dal.ReadCustomer();
            return lstCus;
        }
        public void DeleteEmployee(EmployeeBEL Em)
        {
            dal.DeleteEmployee(Em);
        }
        public void EditEmployee(EmployeeBEL Em)
        {
            dal.EditEmployee(Em);
        }
    }
}

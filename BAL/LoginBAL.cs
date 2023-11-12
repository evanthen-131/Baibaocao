using C_App.DAL;
using C_App.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_App.BAL
{
    internal class LoginBAL
    {
        private LoginDAL dal = new LoginDAL();

        public bool AuthenticateUser(LoginBEL log)
        {
            return dal.AuthenticateUser(log);
        }
    }
}

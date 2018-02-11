using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class UserSingleton
    {

        public static Employee _employee;
        private static UserSingleton Instance { get; set; }
        private UserSingleton()
        {
            _employee = new Employee();
        }
        public static UserSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new UserSingleton();
            }
            return Instance;
        }
        public void LogIn(Employee x)
        {
            _employee = x;
        }
        public string GetCurrentUser()
        {
            return _employee.UserName;
        }
        public string GetCurrentUserType()
        {
            return _employee.Type;
        }
    }
}

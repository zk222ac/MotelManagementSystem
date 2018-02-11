using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Model;
using BookingSystem.Persistancy;


namespace BookingSystem.Catalogs
{
    public class EmployeeCatalog
    {
        private readonly Serialize _serializer;
        private readonly UserSingleton _currentUser;
        public static Employee user;
        public List<Employee> EmployeeList;
        public EmployeeCatalog()
        {
            _serializer = new Serialize();
            _currentUser = UserSingleton.GetInstance();
            EmployeeList = new List<Employee>();
            LoadEmployee();
        }
        public async Task<string> Verify(string userName, string password)
        {
            foreach (var emp in EmployeeList)
            {
                if (userName == emp.UserName && password == emp.Password)
                {
                    _currentUser.LogIn(emp);
                    return emp.Type;
                }
            }
            return null;
        }
        public async void LoadEmployee()
        {
            try
            {
                EmployeeList = await _serializer.LoadEmployees();
            }
            catch (Exception ex)
            {
                EmployeeList.Add(new Employee() { Id = 1, Password = "owner", Type = "Owner", UserName = "ChuckNorris" });
                EmployeeList.Add(new Employee() { Id = 1, Password = "admin", Type = "Administrator", UserName = "Jamshid" });

                _serializer.SaveEmployee(EmployeeList);
            }

        }
    }
}

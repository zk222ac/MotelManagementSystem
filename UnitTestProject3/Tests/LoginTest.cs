using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.ViewModel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestProject3
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void TestLogin()
        {
            LogInViewModel loginVM = new LogInViewModel();
            loginVM.Employees.Password = "wrong";
            loginVM.Employees.UserName = "ChuckNorris";
            loginVM.DoLogInUser();
            Assert.AreSame(loginVM.DisplayText, "Wrong username or password");
        }
    }
}

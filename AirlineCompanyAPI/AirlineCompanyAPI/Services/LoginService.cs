using AirlineCompanyWebAPI.Source.Db;
using AirlineCompanyWebAPI.Models;
using AirlineCompanyAPI.Models.DTOs;

namespace AirlineCompanyWebAPI.Services
{
    public class LoginService
    {
        private readonly UserAccess _userAccess;

        public LoginService()
        {
            _userAccess = new UserAccess(); // Replace with DI in production
        }

        public UserModel Authenticate(UserLoginDTO userLogin)
        {
            return _userAccess.GetUser(userLogin.Username, userLogin.Password);
        }
    }
}

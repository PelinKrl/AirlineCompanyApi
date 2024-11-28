using AirlineCompanyWebAPI.Models;

namespace AirlineCompanyWebAPI.Source.Db
{
    public class UserAccess
    {
        private static readonly List<UserModel> Users = new List<UserModel>
        {
            new UserModel { Username = "admin", Password = "password" },
            new UserModel { Username = "user1", Password = "user1pass" },
            new UserModel { Username = "user2", Password = "user2pass" }
        };

        public UserModel GetUser(string username, string password)
        {
            return Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);
        }
    }
}

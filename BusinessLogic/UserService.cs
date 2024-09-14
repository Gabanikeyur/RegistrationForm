using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserService : IUserService
    {

        UserRepository userRepository = new UserRepository();

        public void AddUser(User user)
        {
            userRepository.InsertUser(user);
        }

        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }

        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public List<City> GetCitiesByState(int stateId)
        {
            return userRepository.GetCitiesByState(stateId);
        }

        public List<State> GetStates()
        {
            return userRepository.GetStates();
        }
    }
}

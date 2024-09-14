using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

    
namespace BusinessLogic
{
    public interface IUserService
    {
        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);

        User GetUserById(int id);

        List<User> GetAllUsers();

        List<City> GetCitiesByState(int stateId);

        List<State> GetStates();
    }
}

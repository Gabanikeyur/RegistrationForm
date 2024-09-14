using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IUserRepository
    {
        void InsertUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);

        User GetUserById(int id);

        List<User> GetAllUsers();

        List<City> GetCitiesByState(int stateId);

        List<State> GetStates();
    }
}

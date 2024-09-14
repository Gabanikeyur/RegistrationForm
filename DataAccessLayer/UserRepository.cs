using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccessLayer
{
    public class UserRepository : IUserRepository
    {

        SqlConnection Connection()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            return cn;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandText = "spGetUser";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 100;
                cn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                sdr.Close();
                if (dt.Rows.Count > 0)
                {
                    users = dt.AsEnumerable().Select(i => new User
                    {
                        Id = i.Field<int>("Id"),
                        Name = i.Field<string>("Name"),
                        Email = i.Field<string>("Email"),
                        Phone = i.Field<string>("Phone"),
                        Address = i.Field<string>("Address"),
                        StateId = i.Field<int>("StateId"),
                        CityId = i.Field<int>("CityId")
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
                dt.Dispose();
            }
            return users;
        }

        public List<City> GetCitiesByState(int stateId)
        {
            List<City> cities = new List<City>();
            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandText = "spGetCity";
                cmd.Parameters.AddWithValue("@Id", stateId);
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 100;
                cn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                sdr.Close();
                if (dt.Rows.Count > 0)
                {
                    cities = dt.AsEnumerable().Select(i => new City
                    {
                        Id = i.Field<int>("Id"),
                        StateId = i.Field<int>("StateId"),
                        CityName = i.Field<string>("City_Name")
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
                dt.Dispose();
            }
            return cities;
        }

        public List<State> GetStates()
        {

            List<State> states = new List<State>();
            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandText = "spGetState";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 100;
                cn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                sdr.Close();
                if (dt.Rows.Count > 0)
                {
                    states = dt.AsEnumerable().Select(i => new State
                    {
                        Id = i.Field<int>("Id"),
                        StateName = i.Field<string>("State_Name")
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
                dt.Dispose();
            }
            return states;
        }

        public User GetUserById(int id)
        {

            User user = new User();
            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandText = "spGetUserById";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 100;
                cn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                sdr.Close();
                if (dt.Rows.Count > 0)
                {
                    user = new User
                    {
                        Id = (int)dt.Rows[0]["Id"],
                        Name = dt.Rows[0]["Name"].ToString(),
                        Email = dt.Rows[0]["Email"].ToString(),
                        Phone = dt.Rows[0]["Phone"].ToString(),
                        Address = dt.Rows[0]["Address"].ToString(),
                        StateId = (int)dt.Rows[0]["StateId"],
                        CityId = (int)dt.Rows[0]["CityId"]
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
                dt.Dispose();
            }
            return user;
        }

        public void InsertUser(User user)
        {
            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "spAddNewUser";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@Address", user.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@StateId", user.StateId);
                cmd.Parameters.AddWithValue("@CityId", user.CityId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }

        }

        public void UpdateUser(User user)
        {

            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "spUpdateUser";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@Address", user.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@StateId", user.StateId);
                cmd.Parameters.AddWithValue("@CityId", user.CityId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }

        }

        public void DeleteUser(int id)
        {

            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "spDeleteUser";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
        }

    }
}

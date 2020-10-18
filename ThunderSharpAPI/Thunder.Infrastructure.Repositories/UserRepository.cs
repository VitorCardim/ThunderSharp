using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;
using Thunder.Domain.Interfaces.Repositories;

namespace Thunder.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public async Task<User> GetUserLoginAsync(Login login)
        {
            try
            {
                using var con = new SqlConnection(_configuration["DefaultConnection"]);
                var sqlCmd =            @$"SELECT  
                                           Person.Email,
                                           Person.Name,
                                           Person.Age,
                                           Person.Password,
                                           Person.PhoneNumber,
                                           Person.ProfileId,
                                           Person.Fee,
                                           Profile.Label
                                           
                                        FROM Person 
                                    JOIN Profile ON Person.ProfileId = Profile.Id
                                    WHERE Person.Email='{login.Email}';
";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;
                await con.OpenAsync();

                var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);

                while (reader.Read())
                {
                    var user = new User(reader["Name"].ToString(),
                                        reader["Email"].ToString(),
                                        reader["Age"].ToString(),
                                        reader["PhoneNumber"].ToString(),
                                        reader["Password"].ToString(),
                                        decimal.Parse(reader["Fee"].ToString()),
                                        new Profile(int.Parse(reader["ProfileId"].ToString()), reader["Label"].ToString()));
                    return user;
                }

                return default;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> InsertUserAsync(User user)
        {
            try
            {
                using var con = new SqlConnection(_configuration["DefaultConnection"]);
                var sqlCmd = @"INSERT INTO 
                                    Person (
                                            Name, 
                                            Email, 
                                            Age,
                                            PhoneNumber,
                                            Password,
                                            ProfileId,
                                            Fee,
                                            Created,
                                            Updated) 

                                    VALUES (
                                            @Name, 
                                            @Email, 
                                            @Age, 
                                            @PhoneNumber,
                                            @Password,
                                            @ProfileId,
                                            @Fee,
                                            @Created,
                                            @Updated
                                        ); SELECT scope_identity();";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProfileId", user.Profile.Id);
                cmd.Parameters.AddWithValue("Name", user.Name);
                cmd.Parameters.AddWithValue("Email", user.Email);
                cmd.Parameters.AddWithValue("Age", user.Age);
                cmd.Parameters.AddWithValue("PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("Password", user.Password);
                cmd.Parameters.AddWithValue("Fee", user.Fee);
                cmd.Parameters.AddWithValue("Updated", user.Updated);
                cmd.Parameters.AddWithValue("Created", user.Created);

                await con.OpenAsync();
                var id = await cmd
                               .ExecuteScalarAsync()
                               .ConfigureAwait(false);

                return int.Parse(id.ToString());
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                using var con = new SqlConnection(_configuration["DefaultConnection"]);
                var sqlCmd = @$"    SELECT
                                           Person.Id, 
                                           Person.Email,
                                           Person.Name,
                                           Person.Age,
                                           Person.Password,
                                           Person.PhoneNumber,
                                           Person.ProfileId
                                    FROM Person 
                                    WHERE Person.Id='{id}';
";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;
                await con.OpenAsync();

                var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);

                while (reader.Read())
                { 
                    return new User(int.Parse(reader["Id"].ToString()));
                }

                return default;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<User>> SearchUserByFeeGenresReservationDates(int genreId, decimal fee, DateTime initialReservation, DateTime finalReservation)
        {
            try
            {
                using var con = new SqlConnection(_configuration["DefaultConnection"]);
                {
                    var searchList = new List<User>();


                    string sqlCmd = @$" SELECT Person.Id, Person.Name, Person.Age, Person.Fee, Person.Email, Person.PhoneNumber 
                                        FROM Person
                                        JOIN Reservation On Reservation.PersonId = Person.Id
                                        JOIN PersonGenres On PersonGenres.PersonId = Person.Id
                                        WHERE PersonGenres.GenreId = '{genreId}'
                                        AND Person.Fee <= '{fee}'
                                        AND   ('{initialReservation}' < Reservation.InitialDate  OR Reservation.FinalDate < '{initialReservation}')
                                        AND   ('{finalReservation}' < Reservation.InitialDate  OR Reservation.FinalDate < '{finalReservation}')          
                                        Group By
                                        Person.Id,
                                        Person.Name,
                                        Person.Age,
                                        Person.Fee, 
                                        Person.PhoneNumber, 
                                        Person.Email;"
                                    ;

                    using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                    cmd.CommandType = CommandType.Text;
                    await con.OpenAsync();

                    var reader = await cmd.ExecuteReaderAsync()
                                            .ConfigureAwait(false);

                    while (reader.Read())
                    {
                        var search = new User(int.Parse(reader["Id"].ToString()),
                                              reader["Name"].ToString(),
                                              reader["Age"].ToString(),
                                              decimal.Parse(reader["Fee"].ToString()),
                                              reader["Email"].ToString(),
                                              reader["PhoneNumber"].ToString());
                        searchList.Add(search);
                    }

                    return searchList;
                }
            }

            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

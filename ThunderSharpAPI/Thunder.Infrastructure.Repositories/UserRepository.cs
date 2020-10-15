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
                using var con = new SqlConnection(_configuration["ConnectionString"]);
                var sqlCmd = @$"SELECT Person.CPF, 
                                           Person.Email,
                                           Person.Name,
                                           Person.Age,
                                           Person.Password,
                                           Person.PhoneNumber,
                                           Person.ProfileId,
                                           Profile.Label 
                                        FROM Person 
                                    JOIN Profile ON Person.ProfileId = Profile.Id
                                    WHERE Person.Email='{login.Email}';
";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);

                while (reader.Read())
                {
                    var user = new User(reader["CPF"].ToString(),
                                        reader["Name"].ToString(),
                                        reader["Email"].ToString(),
                                        reader["Age"].ToString(),
                                        reader["PhoneNumber"].ToString(),
                                        reader["Password"].ToString(),
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
                using var con = new SqlConnection(_configuration["ConnectionString"]);
                var sqlCmd = @"INSERT INTO 
                                    Person (ProfileId,
                                            Name, 
                                            Email, 
                                            Password, 
                                            Age, PhoneNumber,CPF) 
                               VALUES (@profileId, 
                                        @name,
                                        @email, 
                                        @password,
                                        @age, @phoneNumber, CPF
                                        ); SELECT scope_identity();";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProfileId", user.Profile.Id);
                cmd.Parameters.AddWithValue("name", user.Name);
                cmd.Parameters.AddWithValue("email", user.Email);
                cmd.Parameters.AddWithValue("phoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("CPF", user.CPF);

                con.Open();
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
    }
}

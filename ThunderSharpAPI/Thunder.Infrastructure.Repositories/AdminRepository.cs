using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;
using Thunder.Domain.Interfaces.Repository;

namespace Thunder.Infrastructure.Repositories
{
    public class AdminRepository : IAdmin
    {
        private readonly IConfiguration _configuration;
        public AdminRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public Task<Producer> GetProducer(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Register(Register register)
        {

            try
            {
                using var con = new SqlConnection(_configuration["ConnectionString"]);
                var sqlCmd = @"INSERT INTO 
                                  PRODUCER (FullName, 
                                        Email, 
                                        PhoneNumber, 
                                        Age,
                                        Password) 
                               VALUES (@FullName, 
                                        @Email,
                                        @Age, 
                                        @Password);";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con)
                {
                    CommandType = CommandType.Text
                };

                cmd.Parameters.AddWithValue("FullName", "");
                cmd.Parameters.AddWithValue("Email", "");
                cmd.Parameters.AddWithValue("Age", "");
                cmd.Parameters.AddWithValue("Password", "");

                await con.OpenAsync();
                var id = cmd.ExecuteScalar();

                return int.Parse(id.ToString());
            }

            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}

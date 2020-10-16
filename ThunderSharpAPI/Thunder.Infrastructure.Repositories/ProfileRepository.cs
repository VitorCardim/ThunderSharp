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
    public class ProfileRepository : IProfileRepository
    {
        public readonly IConfiguration _configuration;
        public ProfileRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Profile> GetByIdAsync(int id)
        {
            try
            {
                using var con = new SqlConnection(_configuration["DefaultConnection"]);
                var sqlCmd = $@"SELECT *
                                        FROM PROFILE 
                                    WHERE Id={id}";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;
                await con.OpenAsync();

                var reader = await cmd
                                    .ExecuteReaderAsync()
                                    .ConfigureAwait(false);

                while (reader.Read())
                {
                    var profile = new Profile(int.Parse(reader["Id"].ToString()),
                                        reader["Label"].ToString());
                    return profile;
                }
                return default;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

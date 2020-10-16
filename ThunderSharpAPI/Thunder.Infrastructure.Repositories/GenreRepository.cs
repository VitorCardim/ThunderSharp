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
    public class GenreRepository : IGenreRepository
    {
        public readonly IConfiguration _configuration;
        public GenreRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Genre> GetByIdAsync(int id)
        {
            try
            {
                using var con = new SqlConnection(_configuration["ConnectionString"]);
                var sqlCmd = $@"SELECT *
                                        FROM Genres 
                                    WHERE Id={id}";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                var reader = await cmd
                                    .ExecuteReaderAsync()
                                    .ConfigureAwait(false);

                while (reader.Read())
                {
                    var genre = new Genre(int.Parse(reader["Id"].ToString()),
                                        reader["Label"].ToString());
                    return genre;
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

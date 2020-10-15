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
    class ProductionRepository : IProduction
    {
        private readonly IConfiguration _configuration;
        public ProductionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Production> Get()
        {

            throw new NotImplementedException();

        }

        public Task<Production> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Production production)
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
                throw new Exception(ex.Message);
            }

        }
    }
}

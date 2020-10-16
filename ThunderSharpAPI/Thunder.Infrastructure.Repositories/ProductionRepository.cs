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
    public class ProductionRepository : IProductionRepository
    {
        private readonly IConfiguration _configuration;
        public ProductionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Production> Get()
        {

            try
            {
                using (var con = new SqlConnection(_configuration["DefaultConnection"]))
                {
                    var productionList = new List<Production>();
                    var sqlCmd = @"SELECT Id, Name, PersonId, Created, Updated FROM Production";

                    using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            var production = new Production(int.Parse(reader["id"].ToString()),
                                                            reader["name"].ToString(),
                                                            new User(int.Parse(reader["PersonId"].ToString())),
                                                            DateTime.Parse(reader["created"].ToString()),
                                                            DateTime.Parse(reader["updated"].ToString()));

                            productionList.Add(production);
                        }

                        return productionList;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Production> GetByID(int id)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["DefaultConnection"]))
                {
                    var sqlCmd = $@"SELECT Id, Name, PersonId, Created, Updated FROM Production where id = {id}";

                    using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        var reader = await cmd
                                            .ExecuteReaderAsync()
                                            .ConfigureAwait(false);

                        while (reader.Read())
                        {
                            var production = new Production(int.Parse(reader["id"].ToString()),
                                                            reader["name"].ToString(),
                                                            new User(int.Parse(reader["PersonId"].ToString())),
                                                            DateTime.Parse(reader["created"].ToString()),
                                                            DateTime.Parse(reader["updated"].ToString()));
                                

                            return production;
                        }

                        return default;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<int> InsertAsync(Production production)
        {
            try
            {
                using var con = new SqlConnection(_configuration["DefaultConnection"]);
                var sqlCmd = @"INSERT INTO Production
                               (Name, PersonId, Created, Updated) 
                               VALUES 
                               (@Name, @PersonId, @Created, @Updated); SELECT scope_identity();";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con)
                {
                    CommandType = CommandType.Text
                };

                cmd.Parameters.AddWithValue("Name", production.Name);
                cmd.Parameters.AddWithValue("PersonId", production.PersonId);
                cmd.Parameters.AddWithValue("Create", production.Created);
                cmd.Parameters.AddWithValue("Updated", production.Updated);

                await con.OpenAsync();
                var id = await cmd.ExecuteScalarAsync().ConfigureAwait(false);

                return int.Parse(id.ToString());
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}


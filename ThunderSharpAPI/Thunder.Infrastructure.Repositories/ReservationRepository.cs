﻿using Microsoft.Extensions.Configuration;
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
    public class ReservationRepository : IReservationRepository
    {
        private readonly IConfiguration _configuration;

        public ReservationRepository(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public async Task<IEnumerable<Reservation>> GetReservationByUserIdAsync(int id)
        {
            try
            {
                using var con = new SqlConnection(_configuration["DefaultConnection"]);
                {
                    var reservationList = new List<Reservation>();


                    string sqlCmd = @$"SELECT     R.Id, 
                                               R.PersonId,
                                               R.ProductionId,
                                               R.InitialDate,
                                               R.FinalDate,
                                               P.Name,
                                               P.Email,
                                               P.Age,
                                               P.PhoneNumber,
                                               P.Password,
                                               P.ProfileId,
                                               P.Fee,
                                               PF.Label,
                                               PROD.Name as ProductionName,
                                               PROD.Created as ProductionCreated,
                                               PROD.Updated as ProductionUpdated                                            
                                    FROM Reservation R 
                                    JOIN Person P ON R.PersonId = P.Id
                                    JOIN Production PROD ON R.ProductionId = PROD.Id
                                    JOIN Profile PF ON P.ProfileId = PF.Id
                                    WHERE P.Id='{id}';"
                                    ;

                    using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                    cmd.CommandType = CommandType.Text;
                    await con.OpenAsync();

                    var reader = await cmd.ExecuteReaderAsync()
                                            .ConfigureAwait(false);

                    while (reader.Read())
                    {
                        var reservation = new Reservation(
                                            new User(reader["Name"].ToString(),
                                                     reader["Email"].ToString(),
                                                     reader["Age"].ToString(),
                                                     reader["PhoneNumber"].ToString(),
                                                     reader["Password"].ToString(),
                                                     new Profile(
                                                                int.Parse(reader["ProfileId"].ToString()),
                                                                reader["Label"].ToString()),
                                                     decimal.Parse(reader["Fee"].ToString())),
                                                     new Production(int.Parse(reader["ProductionId"].ToString()),
                                                                              reader["ProductionName"].ToString(),
                                                                              int.Parse(reader["PersonId"].ToString()),
                                                                              DateTime.Parse(reader["ProductionCreated"].ToString()),
                                                                              DateTime.Parse(reader["ProductionUpdated"].ToString())),
                                            DateTime.Parse(reader["ProductionCreated"].ToString()),
                                            DateTime.Parse(reader["InitialDate"].ToString()),
                                            DateTime.Parse(reader["FinalDate"].ToString()));
                        reservationList.Add(reservation);
                    }

                    return reservationList;
                }
            }

            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> InsertReservationAsync(Reservation reservation)
        {
            try
            {
                using var con = new SqlConnection(_configuration["DefaultConnection"]);
                var sqlCmd = @"INSERT INTO 
                                    Reservation (PersonId,
                                                 ProductionId, 
                                                 Created, 
                                                 InitialDate, 
                                                 FinalDate) 
                               VALUES ( @personId, 
                                        @productionId,
                                        @created, 
                                        @initialDate,
                                        @finalDate); 
                               SELECT scope_identity();";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PersonId", reservation.User.Id);
                cmd.Parameters.AddWithValue("ProductionId", reservation.Production.Id);
                cmd.Parameters.AddWithValue("Created", reservation.Created);
                cmd.Parameters.AddWithValue("InitialDate", reservation.InitialDate);
                cmd.Parameters.AddWithValue("FinalDate", reservation.FinalDate);

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
        public async Task<Boolean> DeleteReservationAsync(Reservation reservation)
        {
            try
            {
                using var con = new SqlConnection(_configuration["DefaultConnection"]);
                var sqlCmd = @$"DELETE 
                                FROM Reservation
                                WHERE Reservation.Id ='{reservation.Id}';"
                                ;

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                var id = await cmd
                               .ExecuteScalarAsync()
                               .ConfigureAwait(false);

                return true;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}

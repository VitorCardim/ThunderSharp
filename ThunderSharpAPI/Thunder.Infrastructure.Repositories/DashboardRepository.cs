using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;
using Thunder.Domain.Interfaces.Repository;
using System.Linq;

namespace Thunder.Infrastructure.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IConfiguration _configuration;
        
        public DashboardRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public Task<Dashboard> GetByID(string id)
        {
            try
            {
                using var con = new SqlConnection(_configuration["ConnectionString"]);
                var sqlCmd = @$"SELECT COUNT(R.id) 
                                FROM RESERVATION R
                                JOIN PRODUCTION P ON P.id = R.ProductionId
                                WHERE P.CPF = '{id}';";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con)
                {
                    CommandType = CommandType.Text
                };

                await con.OpenAsync();
                int count = (int)cmd.ExecuteScalar();

                return count;
            }

            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

    public Task<Dashboard> GetTotal()
    {
        try
        {
            using var con = new SqlConnection(_configuration["ConnectionString"]);
            var sqlCmd = @$"SELECT COUNT(R.id) 
                                FROM RESERVATION R
                                JOIN PRODUCTION P ON P.id = R.ProductionId;";

            using SqlCommand cmd = new SqlCommand(sqlCmd, con)
            {
                CommandType = CommandType.Text
            };

            await con.OpenAsync();
            int count = (int)cmd.ExecuteScalar();

            return count;
        }

        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public IEnumerable<Dashboard> GetMostReservedDays()
    {
        try
        {
            using var con = new SqlConnection(_configuration["ConnectionString"]);
            {   var reservationTopList = new List<Tuple>();
                var sqlCmd = @$"create Table #tmpDashboard (Quantity int, ReservationDay date)
                            declare @Initialday date = (Select Top 1 Reservation.InitalDate
                                                        From Reservation
                                                        order by Reservation.InitalDate asc);
                            declare @Lastday date = (Select Top 1 Reservation.FinalDate
                                                     From Reservation
                                                     order by Reservation.FinalDate desc);
                            Begin
                                While @Initialday <= @Lastday
                                Begin
                                    Insert into #tmpDashboard (Quantity,ReservationDay) values ((Select count(Reservation.Id) 
                                                                                                 From Reservation 
                                                                                                 where Reservation.InitalDate <= @Initialday 
                                                                                                 and @Initialday <= Reservation.FinalDate), @Initialday)
                                    IF @Initialday = @Lastday
                                        Break;
                                    Set @initialday = dateadd(dd,1,@initialday);
                                END;
                            END;
                            SELECT Top 5 Quantity, ReservationDay
                            From #tmpDashboard
                            Order By Quantity Desc;";

                using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                {
                    CommandType = CommandType.Text;
                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var tupleRervation = new Tuple(reader["Quantity"], reader["ReservationDay"]);

                        reservationTopList.add(tupleRervation);
                    }
                    return reservationTopList;
                }
            }
        }

        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public IEnumerable<Dashboard> GetMostReservedActors()
    {
        try
        {
            using var con = new SqlConnection(_configuration["ConnectionString"]);
            {
                var actorsTopList = new List<Tuple>();
                var sqlCmd = @$"SELECT COUNT(R.CPF) as Quantity, P.Name as Name
                                FROM Reservation R
                                JOIN Person P ON P.CPF = R.CPF
                                GROUP BY Person.CPF
                                ORDER BY Quantity DESC;";

                using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                {
                    CommandType = CommandType.Text;
                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var tupleActors = new Tuple(reader["Quantity"], reader["Name"]);

                        reservationTopList.add(tupleActors);
                    }
                    return actorsTopList;
                }
            }
        }

        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
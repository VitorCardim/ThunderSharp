using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;
using Thunder.Domain.Interfaces.Repositories;
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

        public async Task<DashboardMyReservations> GetByID(string id)
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
                var Dashboard = new DashboardMyReservations(count);
                return Dashboard;
            }

            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<DashboardTotalReservations> GetTotal()
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
                var Dashboard = new DashboardTotalReservations(count);

                return Dashboard;
            }

            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DashboardMostReservedDays>> GetMostReservedDays()
        {
            try
            {
                using var con = new SqlConnection(_configuration["ConnectionString"]);
                {
                    var reservationTopList = new List<DashboardMostReservedDays>();
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
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        var reader = cmd.ExecuteReader();

                        while (await reader.ReadAsync())
                        {
                            var reservation = new DashboardMostReservedDays(reader["ReservationDay"].ToString(), reader["Quantity"].ToString());

                            reservationTopList.Add(reservation);
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

        public async Task<IEnumerable<DashboardMostReservedActors>> GetMostReservedActors()
        {
            try
            {
                using var con = new SqlConnection(_configuration["ConnectionString"]);
                {
                    var actorsTopList = new List<DashboardMostReservedActors>();
                    var sqlCmd = @$"SELECT COUNT(R.CPF) as Quantity, P.Name as Name
                                FROM Reservation R
                                JOIN Person P ON P.CPF = R.CPF
                                GROUP BY Person.CPF
                                ORDER BY Quantity DESC;";

                    using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        var reader = cmd.ExecuteReader();

                        while (await reader.ReadAsync())
                        {
                            var actors = new DashboardMostReservedActors(reader["Name"].ToString(), reader["Quantity"].ToString());

                            actorsTopList.Add(actors);
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
}
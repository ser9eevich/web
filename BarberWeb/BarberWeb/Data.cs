using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BarberWeb.Models;
using Barbershop;

namespace BarberWeb
{
    public class Data
    {
        public static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ClientsDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void Save<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(ConnectionString))
            {
                cnn.Execute(sql, data);
            }
        }

        public static List<T> GetList<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(ConnectionString))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }


        public static void Create(string name, DateTime birth, string phone, DateTime visitDate, TypeService service, int worker)
        {
            var client = new ClientModel()
            {
                ClientName = name,
                Birthday = birth,
                PhoneNumber = phone,
                VisitDate = visitDate,
                Service = ConvertFromEnum(service),
                WorkerId = worker
            };

            string sql = @"insert into dbo.Clients (ClientName, Birthday, PhoneNumber, VisitDate, Service, WorkerId) 
                           values (@ClientName, @Birthday, @PhoneNumber, @VisitDate, @Service, @WorkerId);";

            Save(sql, client);
        }

        public static void CreateWorkersBase(int id, string name, string position, DateTime startDate)
        {
            var worker = new WorkerModel()
            {
                IndividualNumber = id,
                WorkerName = name,
                Position = position,
                StartDate = startDate
            };

            string sql = @"insert into dbo.Workers (IndividualNumber, WorkerName, Position, StartDate) 
                           values (@IndividualNumber, @WorkerName, @Position, @StartDate);";

            Save(sql, worker);
        }

        private static string ConvertFromEnum(TypeService service)
        {
            switch(service)
            {
                case TypeService.BeardStyling: return "Моделирование бороды";
                case TypeService.BeardСorrection: return "Коррекция бороды";
                case TypeService.GreyCamouflage: return "Камуфляж седины";
                case TypeService.HaircutMachine: return "Стрижка машинкой";
                case TypeService.HairStyling: return "Укладка волос";
                case TypeService.MenHaircut: return "Мужская стрижка";
                case TypeService.PremiumShave: return "Премиум бритьё";
                default: throw new Exception();
            }
        }
    }
}

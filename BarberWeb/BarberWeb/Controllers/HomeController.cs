using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Barbershop;
using static BarberWeb.Data;
using BarberWeb.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace BarberWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                try
                {
                    var stream = file.InputStream;
                    var xs = new XmlSerializer(typeof(List<Client>));
                    var clients = (List<Client>)xs.Deserialize(stream);

                    foreach (var c in clients)
                    {
                        Create(c.ClientName, c.Birthday, c.PhoneNumber, c.Appointment.VisitDate,
                            c.Appointment.Service, c.Appointment.Worker.IndividualNumber);
                        var w = c.Appointment.Worker;
                        CreateWorkersBase(w.IndividualNumber, w.WorkerName, w.Position, w.StartDate);
                    }

                    ViewBag.Message = "Файл загружен";
                }
                catch
                {
                    ViewBag.Message = "Файл не может быть загружен";
                }
            }
            return View();
        }

        public ActionResult Clients()
        {
            var sql = @"select WorkerName, ClientName, Birthday, PhoneNumber, VisitDate, Service 
                        from dbo.Workers join dbo.Clients 
                        on WorkerId = IndividualNumber";

            var data = GetList<ClientModel>(sql);

            return View(data);
        }

        public ActionResult Workers()
        {
            var sql = @"select IndividualNumber, WorkerName, Position, StartDate
                           from dbo.Workers;";

            var data = GetList<WorkerModel>(sql);
            return View(data);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BarberWeb.Models
{
    public class ClientModel
    {
        [Display (Name = "Имя клиента")]
        public string ClientName { get; set; }
        [Display (Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }
        [Display (Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        [Display (Name = "Дата посещения")]
        public DateTime VisitDate { get; set; }
        [Display (Name = "Услуга")]
        public string Service { get; set; }
        [Display (Name = "Имя барбера")]
        public string WorkerName { get; set; }
        public int WorkerId { get; set; }
    }
}
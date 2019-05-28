using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BarberWeb.Models
{
    public class WorkerModel
    {
        [Display(Name = "Индивидуальный номер")]
        public int IndividualNumber { get; set; }
        [Display (Name = "Имя сотрудника")]
        public string WorkerName { get; set; }
        [Display (Name = "Статус сотрудника")]
        public string Position { get; set; }
        [Display (Name = "Дата начала работы")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
    }
}
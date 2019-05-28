using System;
using System.Collections.Generic;

namespace Barbershop
{
    /// <sumary>
    /// Клиенты
    /// </sumary>
    public class Client
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Запись
        /// </summary>
        public Appointment Appointment = null;

        public override string ToString()
        {
            return ClientName + ", " + PhoneNumber + " (" + Birthday.ToLongDateString() + ")";
        }
    }

    /// <sumary>
    /// Запись к барберу
    /// </sumary>
    public class Appointment
    {
        /// <summary>
        /// Дата посещения
        /// </summary>
        public DateTime VisitDate { get; set; }
        /// <summary>
        /// Описание услуги
        /// </summary>
        public TypeService Service { get; set; }
        /// <summary>
        /// Сотрудник, выполняющий услугу
        /// </summary>
        public Workers Worker;
    }

    /// <summary>
    /// Сотрудники
    /// </summary>
    public class Workers
    {
        /// <summary>
        /// Индивидуальный номер
        /// </summary>
        public int IndividualNumber { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public string WorkerName { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Дата приема на работу
        /// </summary>
        public DateTime StartDate { get; set; }

        public override string ToString()
        {
            return WorkerName + ", " + Position + " (" + StartDate.ToLongDateString() + ")";
        }
    }

    /// <summary>
    /// Тип услуги
    /// </summary>
    public enum TypeService
    {
        /// <summary>
        /// Мужская стрижка 
        /// </summary>
        MenHaircut,
        /// <summary>
        /// Стрижка машинкой
        /// </summary>
        HaircutMachine,
        /// <summary>
        /// Моделирование бороды
        /// </summary>
        BeardStyling,
        /// <summary>
        /// Коррекция бороды
        /// </summary>
        BeardСorrection,
        /// <summary>
        /// Укладка волос
        /// </summary>
        HairStyling,
        /// <summary>
        /// Камуфляж седины
        /// </summary>
        GreyCamouflage,
        /// <summary>
        /// Премиум бритье
        /// </summary>
        PremiumShave,
    }
}
﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FuelStationBlazor.Shared.Models
{
    public class Operation
    {
        //ID операции
        [Display(Name = "Код операции")]
        public int OperationID { get; set; }
        //ID топлива
        public int FuelID { get; set; }
        //ID емкости
        public int TankID { get; set; }
        //Приход/Расход
        [Display(Name = "+Приход/-Расход")]
        public float? Inc_Exp { get; set; }
        //Дата операции
        [Display(Name = "Дата операции")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        //ссылка на виды топлива
        public virtual Fuel Fuel { get; set; }
        //ссылка на емкости
        public virtual Tank Tank { get; set; }

    }
}

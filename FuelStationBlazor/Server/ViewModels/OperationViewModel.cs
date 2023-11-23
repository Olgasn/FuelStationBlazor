using System;

namespace FuelStationBlazor.Server.ViewModels

{
    public class OperationViewModel
    {
        //ID операции
        public int OperationID { get; set; }
        //ID топлива
        public int FuelID { get; set; }
        //Название вида топлива
        public string FuelType { get; set; }
        //ID емкости
        public int TankID { get; set; }
        //Тип емкости
        public string TankType { get; set; }
        //Приход/Расход
        public float? Inc_Exp { get; set; }
        //Дата операции
        public DateTime Date { get; set; }

        public OperationViewModel()
        {
            OperationID = 0;
            Date = DateTime.Today;
        }
    }
}

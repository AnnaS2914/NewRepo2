using DeviceLibrary;
using System;

namespace DeviceLibrary
{
    public class Device
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public readonly string SerialNumber;

        public RepairType RepairType { get; set; }
        public string FaultDescription { get; set; }
        private decimal repairPrice;
        public decimal RepairPrice
        {
            get => repairPrice;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Неверное значение цены ремонта");
                repairPrice = value;
            }
        }
        public string MasterFullName { get; set; }

        public Device(string name, string manufacturer, string serialNumber)
        {
            Name = name;
            Manufacturer = manufacturer;
            SerialNumber = serialNumber;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[2];
            info[0] = $"{Name} ({Manufacturer}), серийный номер: {SerialNumber}";
            string repairTypeStr;
            if (RepairType == RepairType.Guarantee)
                repairTypeStr = "гарантийный";
            else
                repairTypeStr = "оплачиваемый";
            info[1] = $"Тип ремонта: {repairTypeStr}, неисправность: {FaultDescription}, цена: {RepairPrice:C}, мастер: {MasterFullName}";
            return info;
        }
    }
}
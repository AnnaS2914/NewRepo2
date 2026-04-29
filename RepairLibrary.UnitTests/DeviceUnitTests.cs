using DeviceLibrary;
using NUnit.Framework;
using System;

namespace DeviceLibrary.UnitTests
{
    [TestFixture]
    public class DeviceUnitTests
    {
        private Device CreateTestDevice()
        {
            return new Device("Стиральная машина", "Bosch", "SN12345678");
        }

        [Test]
        public void ConstructorTest()
        {
            Device device = new Device("Стиральная машина", "Bosch", "SN12345678");
            Assert.That(device.Name, Is.EqualTo("Стиральная машина"));
            Assert.That(device.Manufacturer, Is.EqualTo("Bosch"));
            Assert.That(device.SerialNumber, Is.EqualTo("SN12345678"));
        }

        [Test]
        public void RepairPriceNegativeTest()
        {
            Device device = CreateTestDevice();
            Assert.That(() => device.RepairPrice = -100, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void GetInfoTest()
        {
            Device device = CreateTestDevice();
            device.RepairType = RepairType.Paid;
            device.FaultDescription = "Не греет воду";
            device.RepairPrice = 2500;
            device.MasterFullName = "Иванов И.И.";

            string[] info = device.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("Стиральная машина (Bosch), серийный номер: SN12345678"));

            string repairTypeStr;
            if (device.RepairType == RepairType.Guarantee)
                repairTypeStr = "гарантийный";
            else
                repairTypeStr = "оплачиваемый";

            string expected = $"Тип ремонта: {repairTypeStr}, неисправность: {device.FaultDescription}, цена: {device.RepairPrice:C}, мастер: {device.MasterFullName}";
            Assert.That(info[1], Is.EqualTo(expected));
        }
    }
}
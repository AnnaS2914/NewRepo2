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

    [TestFixture]
    public class TelevisionUnitTests
    {
        private Television CreateTestTelevision()
        {
            return new Television("QLED 55Q80", "Samsung", "SN123456", 55.0, "QLED", "Direct");
        }

        [Test]
        public void ConstructorTest()
        {
            Television tv = new Television("QLED 55Q80", "Samsung", "SN123456", 55.0, "QLED", "Direct");
            Assert.That(tv.Name, Is.EqualTo("QLED 55Q80"));
            Assert.That(tv.Manufacturer, Is.EqualTo("Samsung"));
            Assert.That(tv.SerialNumber, Is.EqualTo("SN123456"));
            Assert.That(tv.ScreenDiagonal, Is.EqualTo(55.0));
            Assert.That(tv.MatrixType, Is.EqualTo("QLED"));
            Assert.That(tv.BacklightType, Is.EqualTo("Direct"));
        }

        [Test]
        public void GetInfoTest()
        {
            Television tv = CreateTestTelevision();
            tv.RepairType = RepairType.Guarantee;
            tv.FaultDescription = "не включается";
            tv.RepairPrice = 3500;
            tv.MasterFullName = "Иванов И.И.";

            string[] info = tv.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[0], Is.EqualTo("QLED 55Q80 (Samsung), серийный номер: SN123456"));

            string repairTypeStr;
            if (tv.RepairType == RepairType.Guarantee)
                repairTypeStr = "гарантийный";
            else
                repairTypeStr = "оплачиваемый";

            string expectedInfo1 = $"Тип ремонта: {repairTypeStr}, неисправность: {tv.FaultDescription}, цена: {tv.RepairPrice:C}, мастер: {tv.MasterFullName}";
            Assert.That(info[1], Is.EqualTo(expectedInfo1));

            string expectedInfo2 = $"Телевизор: диагональ {tv.ScreenDiagonal}\", матрица {tv.MatrixType}, подсветка {tv.BacklightType}";
            Assert.That(info[2], Is.EqualTo(expectedInfo2));
        }
    }

    [TestFixture]
    public class RefrigeratorUnitTests
    {
        private Refrigerator CreateTestRefrigerator()
        {
            return new Refrigerator("RB37A", "LG", "SN654321", 2, 185.0, 60.0, 65.0);
        }

        [Test]
        public void ConstructorTest()
        {
            Refrigerator fridge = new Refrigerator("RB37A", "LG", "SN654321", 2, 185.0, 60.0, 65.0);
            Assert.That(fridge.Name, Is.EqualTo("RB37A"));
            Assert.That(fridge.Manufacturer, Is.EqualTo("LG"));
            Assert.That(fridge.SerialNumber, Is.EqualTo("SN654321"));
            Assert.That(fridge.CameraCount, Is.EqualTo(2));
            Assert.That(fridge.Height, Is.EqualTo(185.0));
            Assert.That(fridge.Width, Is.EqualTo(60.0));
            Assert.That(fridge.Depth, Is.EqualTo(65.0));
        }

        [Test]
        public void GetInfoTest()
        {
            Refrigerator fridge = CreateTestRefrigerator();
            fridge.RepairType = RepairType.Paid;
            fridge.FaultDescription = "не морозит";
            fridge.RepairPrice = 5000;
            fridge.MasterFullName = "Петров П.П.";

            string[] info = fridge.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));

            Assert.That(info[0], Is.EqualTo("RB37A (LG), серийный номер: SN654321"));

            string repairTypeStr;
            if (fridge.RepairType == RepairType.Guarantee)
                repairTypeStr = "гарантийный";
            else
                repairTypeStr = "оплачиваемый";

            string expectedInfo1 = $"Тип ремонта: {repairTypeStr}, неисправность: {fridge.FaultDescription}, цена: {fridge.RepairPrice:C}, мастер: {fridge.MasterFullName}";
            Assert.That(info[1], Is.EqualTo(expectedInfo1));

            string expectedInfo2 = $"Холодильник: камер — {fridge.CameraCount}, габариты (В×Ш×Г): {fridge.Height}×{fridge.Width}×{fridge.Depth} см";
            Assert.That(info[2], Is.EqualTo(expectedInfo2));
        }
    }
}
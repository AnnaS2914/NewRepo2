using DeviceLibrary;

[TestFixture]
public class ServiceTests
{
    private Service service;
    private Device device1;
    private Device device2;
    private Device device3;

    [SetUp]
    public void Setup()
    {
        service = new Service("FF-сервис", "проспект Ленина, д. 51", "+7 (495) 296 96 24");

        device1 = new Device("Стиральная машина", "Bosch", "SN12345678")
        {
            MasterFullName = "Иванов И.И.",
            Name = "Стиральная машина"
        };

        device2 = new Device("Холодильник", "LG", "SN87654321")
        {
            MasterFullName = "Иванов И.И.",
            Name = "Холодильник"
        };

        device3 = new Device("Телевизор", "Samsung", "SN11112222")
        {
            MasterFullName = "Петров П.П.",
            Name = "Телевизор"
        };
    }

    [Test]
    public void ConstructorTest()
    {
        Assert.That(service.ServiceName, Is.EqualTo("FF-сервис"));
        Assert.That(service.Address, Is.EqualTo("проспект Ленина, д. 51"));
        Assert.That(service.Phone, Is.EqualTo("+7 (495) 296 96 24"));
        Assert.That(service.Count, Is.EqualTo(0));
    }

    [Test]
    public void AddDeviceTest()
    {
        service.AddDevice(device1);

        Assert.That(service.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddDeviceDuplicateTest()
    {
        service.AddDevice(device1);
        service.AddDevice(device1);

        Assert.That(service.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddNullDeviceTest()
    {
        Assert.That(() => service.AddDevice(null), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void RemoveDeviceByReferenceTest()
    {
        service.AddDevice(device1);
        service.AddDevice(device2);

        bool result = service.RemoveDevice(device1);

        Assert.That(result, Is.True);
        Assert.That(service.Count, Is.EqualTo(1));
    }

    [Test]
    public void RemoveDeviceBySerialNumberTest()
    {
        service.AddDevice(device1);
        service.AddDevice(device2);

        bool result = service.RemoveDevice("SN12345678");

        Assert.That(result, Is.True);
        Assert.That(service.Count, Is.EqualTo(1));
    }

    [Test]
    public void RemoveNonExistentDeviceTest()
    {
        service.AddDevice(device1);

        bool result = service.RemoveDevice(device3);

        Assert.That(result, Is.False);
        Assert.That(service.Count, Is.EqualTo(1));
    }

    [Test]
    public void RemoveDeviceByNonExistentSerialNumberTest()
    {
        service.AddDevice(device1);

        bool result = service.RemoveDevice("SN99999999");

        Assert.That(result, Is.False);
        Assert.That(service.Count, Is.EqualTo(1));
    }

    [Test]
    public void CountTest()
    {
        service.AddDevice(device1);
        service.AddDevice(device2);
        service.AddDevice(device3);

        Assert.That(service.Count, Is.EqualTo(3));
    }

    [Test]
    public void IEnumerableTest()
    {
        service.AddDevice(device1);
        service.AddDevice(device2);
        service.AddDevice(device3);

        var devices = new Device[] { device1, device2, device3 };
        int index = 0;

        foreach (var device in service)
        {
            Assert.That(device, Is.SameAs(devices[index]));
            index++;
        }

        Assert.That(index, Is.EqualTo(3));
    }

    [Test]
    public void DeviceCompareToTest()
    {
        device1.MasterFullName = "Андреев А.А.";
        device1.Name = "Микроволновая печь";

        device2.MasterFullName = "Андреев А.А.";
        device2.Name = "Кофеварка";

        device3.MasterFullName = "Борисов Б.Б.";
        device3.Name = "Тостер";

        Assert.That(device2.CompareTo(device1), Is.LessThan(0));
        Assert.That(device1.CompareTo(device2), Is.GreaterThan(0));
        Assert.That(device1.CompareTo(device3), Is.LessThan(0));
        Assert.That(device2.CompareTo(device3), Is.LessThan(0));
        Assert.That(device3.CompareTo(device3), Is.EqualTo(0));
    }
}
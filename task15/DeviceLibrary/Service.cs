using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DeviceLibrary
{
    public class Service : IEnumerable<Device>
    {
        public string ServiceName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        private List<Device> devicesInRepair;

        public int Count { get => devicesInRepair.Count; }

        public Service(string serviceName, string address, string phone)
        {
            ServiceName = serviceName;
            Address = address;
            Phone = phone;
            devicesInRepair = new List<Device>();
        }

        public void AddDevice(Device device)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            if (!devicesInRepair.Contains(device))
                devicesInRepair.Add(device);
        }

        public bool RemoveDevice(Device device)
        {
            return devicesInRepair.Remove(device);
        }

        public bool RemoveDevice(string serialNumber)
        {
            var device = devicesInRepair.FirstOrDefault(d => d.SerialNumber == serialNumber);
            if (device != null)
                return devicesInRepair.Remove(device);
            return false;
        }

        public IEnumerator<Device> GetEnumerator()
        {
            return devicesInRepair.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
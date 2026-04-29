using System;

namespace DeviceLibrary
{
    public class Refrigerator : Device
    {
        public int CameraCount { get; set; }
        public double Height { get; set; } // см
        public double Width { get; set; }  // см
        public double Depth { get; set; }  // см

        public Refrigerator(string name, string manufacturer, string serialNumber,
            int cameraCount, double height, double width, double depth)
            : base(name, manufacturer, serialNumber)
        {
            CameraCount = cameraCount;
            Height = height;
            Width = width;
            Depth = depth;
        }

        public override string[] GetInfo()
        {
            var info = new string[3];
            var deviceInfo = base.GetInfo();
            info[0] = deviceInfo[0];
            info[1] = deviceInfo[1];
            info[2] = $"Холодильник: камер — {CameraCount}, " +
                      $"габариты (В×Ш×Г): {Height}×{Width}×{Depth} см";
            return info;
        }
    }
}
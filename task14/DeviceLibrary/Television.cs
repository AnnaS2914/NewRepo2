using System;

namespace DeviceLibrary
{
    public class Television : Device
    {
        public double ScreenDiagonal { get; set; }
        public string MatrixType { get; set; }
        public string BacklightType { get; set; } 

        public Television(string name, string manufacturer, string serialNumber,
            double screenDiagonal, string matrixType, string backlightType)
            : base(name, manufacturer, serialNumber)
        {
            ScreenDiagonal = screenDiagonal;
            MatrixType = matrixType;
            BacklightType = backlightType;
        }

        public override string[] GetInfo()
        {
            var info = new string[3];
            var deviceInfo = base.GetInfo();
            info[0] = deviceInfo[0];
            info[1] = deviceInfo[1];
            info[2] = $"Телевизор: диагональ {ScreenDiagonal}\", " +
                      $"матрица {MatrixType}, подсветка {BacklightType}";
            return info;
        }
    }
}
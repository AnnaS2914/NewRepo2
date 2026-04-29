using System;

namespace EllipseStruct
{
    public struct Ellipse
    {
        private double a;
        private double b;

        public double A
        {
            get => a;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Полуось должна быть положительным числом");
                a = value;
            }
        }

        public double B
        {
            get => b;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Полуось должна быть положительным числом");
                b = value;
            }
        }

        public double E
        {
            get
            {
                if (a >= b)
                    return Math.Sqrt(a * a - b * b) / a;
                else
                    return Math.Sqrt(b * b - a * a) / b;
            }
        }

        public double Area
        {
            get => Math.PI * a * b;
        }

        public Ellipse(double a, double b) : this()
        {
            A = a;
            B = b;
        }

        public override string ToString() =>
            string.Format(System.Globalization.CultureInfo.InvariantCulture,
                          "Эллипс с полуосями а = {0} и b = {1}", A, B);

        public override bool Equals(object obj)
        {
            if (obj is Ellipse)
            {
                const double eps = 1e-13;
                Ellipse other = (Ellipse)obj;
                return Math.Abs(A - other.A) < eps && Math.Abs(B - other.B) < eps;
            }
            throw new ArgumentException("Объект для сравнения не является эллипсом");
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                const int p = 23;
                hash = hash * p + A.GetHashCode();
                hash = hash * p + B.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Ellipse x, Ellipse y) => x.Equals(y);
        public static bool operator !=(Ellipse x, Ellipse y) => !x.Equals(y);

        public static Ellipse operator *(double k, Ellipse ellipse)
        {
            if (k <= 0)
                throw new ArgumentException("Коэффициент должен быть положительным числом");
            return new Ellipse(ellipse.A * k, ellipse.B * k);
        }

        public static Ellipse operator *(Ellipse ellipse, double k) => k * ellipse;
    }
}
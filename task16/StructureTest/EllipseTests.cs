using NUnit.Framework;

namespace EllipseStruct.UnitTests
{
    [TestFixture]
    public class EllipseTests
    {
        [Test]
        public void ConstructorTest()
        {
            var ellipse = new Ellipse(6.2, 3.21);
            Assert.That(ellipse.A, Is.EqualTo(6.2).Within(1e-13));
            Assert.That(ellipse.B, Is.EqualTo(3.21).Within(1e-13));
        }

        [TestCase(-1.0)]
        [TestCase(0.0)]
        public void A_SetNegativeOrZeroValue_ArgumentException(double val)
        {
            var ellipse = new Ellipse();
            Assert.That(() => ellipse.A = val, Throws.ArgumentException);
        }

        [TestCase(-1.0)]
        [TestCase(0.0)]
        public void B_SetNegativeOrZeroValue_ArgumentException(double val)
        {
            var ellipse = new Ellipse();
            Assert.That(() => ellipse.B = val, Throws.ArgumentException);
        }

        [TestCase(6.2, 3.21, 0.8555368421297912)]
        [TestCase(3.21, 6.2, 0.8555368421297912)]
        [TestCase(5.0, 5.0, 0.0)]
        public void ETest(double a, double b, double result)
        {
            var ellipse = new Ellipse(a, b);
            Assert.That(ellipse.E, Is.EqualTo(result).Within(1e-13));
        }

        [TestCase(6.2, 3.21, 62.523976991744064)]
        [TestCase(0.5, 1.5, 2.356194490192345)]
        public void AreaTest(double a, double b, double result)
        {
            var ellipse = new Ellipse(a, b);
            Assert.That(ellipse.Area, Is.EqualTo(result).Within(1e-13));
        }

        [TestCase(6.2, 3.21, "Эллипс с полуосями а = 6.2 и b = 3.21")]
        [TestCase(0.5, 1.5, "Эллипс с полуосями а = 0.5 и b = 1.5")]
        public void ToStringTest(double a, double b, string result)
        {
            var ellipse = new Ellipse(a, b);
            Assert.That(ellipse.ToString(), Is.EqualTo(result));
        }

        [TestCase(6.2, 3.21, 6.2, 3.21, true)]
        [TestCase(6.2, 3.21, 6.2, 4.0, false)]
        [TestCase(6.2, 3.21, 5.0, 3.21, false)]
        public void Equals_TwoEllipses_ExpectedResult(double a1, double b1, double a2, double b2, bool result)
        {
            var ellipse1 = new Ellipse(a1, b1);
            var ellipse2 = new Ellipse(a2, b2);
            Assert.That(ellipse1.Equals(ellipse2), Is.EqualTo(result));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var ellipse = new Ellipse();
            var smth = new object();
            Assert.That(() => ellipse.Equals(smth), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCodeTest()
        {
            var x = new Ellipse(6.2, 3.21);
            var y = new Ellipse(6.2, 3.21);
            var z = new Ellipse(5.0, 4.0);

            Assert.That(x.Equals(y), Is.True);
            Assert.That(x.Equals(z), Is.False);
        }

        [Test]
        public void ComparisonTest()
        {
            var x = new Ellipse(6.2, 3.21);
            var y = new Ellipse(6.2, 3.21);
            var z = new Ellipse(5.0, 4.0);

            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }

        [TestCase(2.0, 6.2, 3.21, 12.4, 6.42)]
        [TestCase(0.5, 6.2, 3.21, 3.1, 1.605)]
        [TestCase(1.0, 5.0, 4.0, 5.0, 4.0)]
        public void MultiplicationTest(double k, double a, double b, double resultA, double resultB)
        {
            var ellipse = new Ellipse(a, b);
            var expected = new Ellipse(resultA, resultB);

            Assert.That(k * ellipse, Is.EqualTo(expected));
            Assert.That(ellipse * k, Is.EqualTo(expected));
        }

        [TestCase(-1.0)]
        [TestCase(0.0)]
        public void Multiplication_NegativeOrZeroCoefficient_ArgumentException(double k)
        {
            var ellipse = new Ellipse(6.2, 3.21);
            Assert.That(() => k * ellipse, Throws.ArgumentException);
            Assert.That(() => ellipse * k, Throws.ArgumentException);
        }
    }
}
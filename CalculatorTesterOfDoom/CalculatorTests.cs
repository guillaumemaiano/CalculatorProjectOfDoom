using CalculatorProject.Model;
using NUnit.Framework;

namespace CalculatorTesterOfDoom
{
    public class CalculatorTests
    {
        private CalculatorModel model;
        [SetUp]
        public void Setup()
        {
            model = new CalculatorModel();
        }

        [Test]
        public void TestArea()
        {
            model.Width = 5;
            model.Height = 8;
            double area = model.area();
            Assert.AreEqual(area, 40);
        }
    }
}
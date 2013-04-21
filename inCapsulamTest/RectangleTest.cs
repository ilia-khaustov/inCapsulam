using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using inCapsulam.Rectangles;
using System.Diagnostics;

namespace inCapsulamTest
{
    [TestClass]
    public class RectangleTest
    {
        [TestMethod]
        public void compareRectangles()
        {
            Rectangle r1 = new Rectangle(2, 2, 4, 4);
            Rectangle r2 = new Rectangle(2, 2, 8, 8);
            Assert.IsTrue(r1.Space < r2.Space);
        }

        [TestMethod]
        public void checkIfRectanglesIntersect()
        {
            Rectangle r1 = new Rectangle(2, 2, 4, 4);
            Rectangle r2 = new Rectangle(2, 2, 8, 8);

            Trace.WriteLine("Checking " + (r1 - r2).Space + " > 0");
            Assert.IsTrue((r1 - r2).Space > 0);

            Trace.WriteLine("Checking " + (r2 - r1).Space + " > 0");
            Assert.IsTrue((r2 - r1).Space > 0);

            Rectangle r3 = new Rectangle(6, 6, 8, 8);

            Trace.WriteLine("Checking " + (r1 - r3).Space + " = 0");
            Assert.IsTrue((r1 - r3).Space == 0);

            Trace.WriteLine("Checking " + (r3 - r1).Space + " = 0");
            Assert.IsTrue((r3 - r1).Space == 0);

            Trace.WriteLine("Checking " + (r1 - r1).Space + " = " + r1.Space);
            Assert.IsTrue((r1 - r1).Space == r1.Space);
        }

    }
}

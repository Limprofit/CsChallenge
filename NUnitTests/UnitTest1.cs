using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CsChallenge;

namespace NUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimpleDictTest()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>
            {
                { 0, 7 },
                { 1, 5 },
                { 5, 4 },
                { 7, 10 },
                { -5, 1 }
            };

            Assert.AreEqual((-5, 1), Program.FindLeastFrequent(dict));
        }

        [TestMethod]
        public void SingleNumberTest()
        {
            string file = @"..\..\..\..\NUnitTests\src\SingleNumber.txt";

            Dictionary<int, int> dict = new Dictionary<int, int>
            {
                { 39, 1 }
            };

            CollectionAssert.AreEqual(dict, Program.CreateFreqDict(file).Item1);
        }

        [TestMethod]
        public void AllPositives()
        {
            string file = @"..\..\..\..\NUnitTests\src\AllPositives.txt";

            (Dictionary<int, int> dict, _) = Program.CreateFreqDict(file);

            Assert.AreEqual((6, 7), Program.FindLeastFrequent(dict));
        }

        [TestMethod]
        public void AllNegatives()
        {
            string file = @"..\..\..\..\NUnitTests\src\AllNegatives.txt";

            (Dictionary<int, int> dict, _) = Program.CreateFreqDict(file);

            Assert.AreEqual((-9, 10), Program.FindLeastFrequent(dict));
        }

        [TestMethod]
        public void MultipleIntegers1()
        {
            string file = @"..\..\..\..\NUnitTests\src\MultipleIntegers1.txt";

            (Dictionary<int, int> dict, _) = Program.CreateFreqDict(file);

            Assert.AreEqual((9, 1), Program.FindLeastFrequent(dict));
        }

        [TestMethod]
        public void MultipleIntegers2()
        {
            string file = @"..\..\..\..\NUnitTests\src\MultipleIntegers2.txt";

            (Dictionary<int, int> dict, _) = Program.CreateFreqDict(file);

            Assert.AreEqual((-30, 1), Program.FindLeastFrequent(dict));
        }

        [TestMethod]
        public void MultipleIntegers3()
        {
            string file = @"..\..\..\..\NUnitTests\src\MultipleIntegers3.txt";

            (Dictionary<int, int> dict, _) = Program.CreateFreqDict(file);

            Assert.AreEqual((1, 24), Program.FindLeastFrequent(dict));
        }

        [TestMethod]
        public void NaNTest()
        {
            string file = @"..\..\..\..\NUnitTests\src\NaN.txt";

            (Dictionary<int, int> dict, _) = Program.CreateFreqDict(file);

            Assert.AreEqual((0, 1), Program.FindLeastFrequent(dict));
        }

        [TestMethod]
        public void OverflowTest()
        {
            string file = @"..\..\..\..\NUnitTests\src\Overflow.txt";

            (Dictionary<int, int> dict, _) = Program.CreateFreqDict(file);

            Assert.AreEqual((0, 2), Program.FindLeastFrequent(dict));
        }
    }
}

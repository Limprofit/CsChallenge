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

            CollectionAssert.AreEqual(dict, Program.CreateFreqDict(file));
        }

        [TestMethod]
        public void AllPositives()
        {
            string file = @"..\..\..\..\NUnitTests\src\AllPositives.txt";

            Dictionary<int, int> dict = Program.CreateFreqDict(file);

            Assert.AreEqual((6, 7), Program.FindLeastFrequent(dict));
        }

        [TestMethod]
        public void AllNegatives()
        {
            string file = @"..\..\..\..\NUnitTests\src\AllNegatives.txt";

            Dictionary<int, int> dict = Program.CreateFreqDict(file);

            Assert.AreEqual((-9, 10), Program.FindLeastFrequent(dict));
        }
    }
}
